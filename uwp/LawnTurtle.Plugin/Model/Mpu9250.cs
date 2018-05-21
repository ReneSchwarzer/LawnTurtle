using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.I2c;

namespace LawnTurtle.Plugin.Model
{
    /// <summary>
    /// access acceleration. gyroscope and temperature data
    /// </summary>
    public class Mpu9250 : IDisposable
    {
        // Adressen
        private const byte WHO_AM_I = 0x75;         // WHO AM I

        // Optionen
        private const byte SMPLRT_20Hz = 0x13;      // SAMPLE Rate 50ms
        private const byte CONFIG_94Hz = 0x02;      // FILTER accelerometer 94Hz
        private const byte PWR_MNGMT_ZCLOCK = 0x03; // PLL with Z axis gyroscope reference
        private const byte GYRO_CONFIG_500 = 0x08;  // GYRO +/- 500deg/s
        private const byte ACCEL_CONFIG_4g = 0x0A;  // ACCELEROMETER +/- 4g -> 2.5Hz filter
        private const byte BYPASS_ENABLED = 0x02;   // COMPAS direct reading enabled

        private float[] gyroBias = new float[3];
        private float[] accelBias = new float[3];

        /// <summary>
        /// Liefert die I2C-Adresse
        /// </summary>
        public Mpu9250Address Address { get; private set; }

        /// <summary>
        /// Liefert oder setzt die Adresse
        /// </summary>
        public string WHO_AM_I_Address { get; set; }

        /// <summary>
        /// Liefert oder setzt das I2cDevice
        /// </summary>
        private I2cDevice MPU { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="address">Die I2C-Adresse</param>
        public Mpu9250(Mpu9250Address address = Mpu9250Address.ADO0)
        {
            Address = address;
        }

        /// <summary>
        /// Bereinigung
        /// </summary>
        public void Dispose()
        {
            MPU.Dispose();
        }

        /// <summary>
        /// Initialisierung
        /// </summary>
        public async void InitAsync()
        {
            var settings = new I2cConnectionSettings((int)Address);
            settings.BusSpeed = I2cBusSpeed.FastMode;

            var controller = await I2cController.GetDefaultAsync();
            MPU = controller.GetDevice(settings);

            MPU.Write(new byte[] { (byte)Mpu9250Register.SMPLRT_DIV, SMPLRT_20Hz });
            MPU.Write(new byte[] { (byte)Mpu9250Register.CONFIG, CONFIG_94Hz });
            MPU.Write(new byte[] { (byte)Mpu9250Register.GYRO_CONFIG, GYRO_CONFIG_500 });
            MPU.Write(new byte[] { (byte)Mpu9250Register.ACCEL_CONFIG, ACCEL_CONFIG_4g });
            MPU.Write(new byte[] { (byte)Mpu9250Register.BYPASS, BYPASS_ENABLED });
            MPU.Write(new byte[] { (byte)Mpu9250Register.PWR_MNGMT_1, PWR_MNGMT_ZCLOCK });

            var whoAmI = new byte[1];
            MPU.WriteRead(new byte[] { WHO_AM_I }, whoAmI); // Should return 0x71
            WHO_AM_I_Address = BitConverter.ToString(whoAmI);

            Calibrate();
        }

        /// <summary>
        /// Kalibrieren
        /// </summary>
        public void Calibrate()
        {
            // reset device
            // Write a one to bit 7 reset bit; toggle reset device
            MPU.Write(new byte[] { (byte)Mpu9250Register.PWR_MNGMT_1, 0x80 });
            Thread.Sleep(100);

            // get stable time source; Auto select clock source to be PLL gyroscope
            // reference if ready else use the internal oscillator, bits 2:0 = 001
            MPU.Write(new byte[] { (byte)Mpu9250Register.PWR_MNGMT_1, 0x01 });
            MPU.Write(new byte[] { (byte)Mpu9250Register.PWR_MNGMT_2, 0x00 });
            Thread.Sleep(200);

            // Configure device for bias calculation
            MPU.Write(new byte[] { (byte)Mpu9250Register.INT_ENABLE, 0x00 });   // Disable all interrupts
            MPU.Write(new byte[] { (byte)Mpu9250Register.FIFO_EN, 0x00 });      // Disable FIFO
            MPU.Write(new byte[] { (byte)Mpu9250Register.PWR_MNGMT_1, 0x00 });  // Turn on internal clock source
            MPU.Write(new byte[] { (byte)Mpu9250Register.I2C_MST_CTRL, 0x00 }); // Disable I2C master
            MPU.Write(new byte[] { (byte)Mpu9250Register.USER_CTRL, 0x00 });    // Disable FIFO and I2C master modes
            MPU.Write(new byte[] { (byte)Mpu9250Register.USER_CTRL, 0x0C });    // Reset FIFO and DMP
            Thread.Sleep(15);

            // Configure MPU6050 gyro and accelerometer for bias calculation
            MPU.Write(new byte[] { (byte)Mpu9250Register.CONFIG, 0x01 });       // Set low-pass filter to 188 Hz
            MPU.Write(new byte[] { (byte)Mpu9250Register.SMPLRT_DIV, 0x00 });   // Set sample rate to 1 kHz
            MPU.Write(new byte[] { (byte)Mpu9250Register.GYRO_CONFIG, 0x00 });  // Set gyro full-scale to 250 degrees per second, maximum sensitivity
            MPU.Write(new byte[] { (byte)Mpu9250Register.ACCEL_CONFIG, 0x00 }); // Set accelerometer full-scale to 2 g, maximum sensitivity

            // Configure FIFO to capture accelerometer and gyro data for bias calculation
            MPU.Write(new byte[] { (byte)Mpu9250Register.USER_CTRL, 0x40 });    // Enable FIFO  
            MPU.Write(new byte[] { (byte)Mpu9250Register.FIFO_EN, 0x78 });      // Enable gyro and accelerometer sensors for FIFO  (max size 512 bytes in MPU-9150)
            Thread.Sleep(40); // accumulate 40 samples in 40 milliseconds = 480 bytes

            // At end of sample accumulation, turn off FIFO sensor read
            var data = new byte[2];
            MPU.Write(new byte[] { (byte)Mpu9250Register.FIFO_EN, 0x00 });  // Disable gyro and accelerometer sensors for FIFO
            MPU.WriteRead(new byte[] { (byte)Mpu9250Register.FIFO_COUNTH }, data); // read FIFO sample count

            var fifo_count = (data[0] << 8) | data[1];
            var packet_count = fifo_count / 12; // How many sets of full gyro and accelerometer data for averaging

            data = new byte[12];
            int[] gyro_bias = { 0, 0, 0 }, accel_bias = { 0, 0, 0 };
            for (int i = 0; i < packet_count; i++)
            {
                int[] accel_temp = { 0, 0, 0 }, gyro_temp = { 0, 0, 0 };
                MPU.WriteRead(new byte[] { (byte)Mpu9250Register.FIFO_R_W }, data); // read data for averaging

                accel_temp[0] = ((data[0] << 8) | data[1]);  // Form signed 16-bit integer for each sample in FIFO
                accel_temp[1] = ((data[2] << 8) | data[3]);
                accel_temp[2] = ((data[4] << 8) | data[5]);
                gyro_temp[0] = ((data[6] << 8) | data[7]);
                gyro_temp[1] = ((data[8] << 8) | data[9]);
                gyro_temp[2] = ((data[10] << 8) | data[11]);

                accel_bias[0] += accel_temp[0]; // Sum individual signed 16-bit biases to get accumulated signed 32-bit biases
                accel_bias[1] += accel_temp[1];
                accel_bias[2] += accel_temp[2];
                gyro_bias[0] += gyro_temp[0];
                gyro_bias[1] += gyro_temp[1];
                gyro_bias[2] += gyro_temp[2];
            }

            accel_bias[0] /= packet_count; // Normalize sums to get average count biases
            accel_bias[1] /= packet_count;
            accel_bias[2] /= packet_count;
            gyro_bias[0] /= packet_count;
            gyro_bias[1] /= packet_count;
            gyro_bias[2] /= packet_count;

            var accelsensitivity = 16384;  // = 16384 LSB/g

            if (accel_bias[2] > 0L)
            {
                // Remove gravity from the z-axis accelerometer bias calculation
                accel_bias[2] -= accelsensitivity;
            }  
            else
            {
                accel_bias[2] += accelsensitivity;
            }

            // Construct the gyro biases for push to the hardware gyro bias registers, which are reset to zero upon device startup
            data[0] = (byte)((-gyro_bias[0] / 4 >> 8) & 0xFF);  // Divide by 4 to get 32.9 LSB per deg/s to conform to expected bias input format
            data[1] = (byte)((-gyro_bias[0] / 4) & 0xFF);       // Biases are additive, so change sign on calculated average gyro biases
            data[2] = (byte)((-gyro_bias[1] / 4 >> 8) & 0xFF);
            data[3] = (byte)((-gyro_bias[1] / 4) & 0xFF);
            data[4] = (byte)((-gyro_bias[2] / 4 >> 8) & 0xFF);
            data[5] = (byte)((-gyro_bias[2] / 4) & 0xFF);

            // Push gyro biases to hardware registers
            MPU.Write(new byte[] { (byte)Mpu9250Register.XG_OFFSET_H, data[0] });
            MPU.Write(new byte[] { (byte)Mpu9250Register.XG_OFFSET_L, data[1] });
            MPU.Write(new byte[] { (byte)Mpu9250Register.YG_OFFSET_H, data[2] });
            MPU.Write(new byte[] { (byte)Mpu9250Register.YG_OFFSET_L, data[3] });
            MPU.Write(new byte[] { (byte)Mpu9250Register.ZG_OFFSET_H, data[4] });
            MPU.Write(new byte[] { (byte)Mpu9250Register.ZG_OFFSET_L, data[5] });

            // Output scaled gyro biases for display in the main program
            var gyrosensitivity = 131;   // = 131 LSB/degrees/sec
            gyroBias[0] = (float)gyro_bias[0] / (float)gyrosensitivity;
            gyroBias[1] = (float)gyro_bias[1] / (float)gyrosensitivity;
            gyroBias[2] = (float)gyro_bias[2] / (float)gyrosensitivity;

            // Construct the accelerometer biases for push to the hardware accelerometer bias registers. These registers contain
            // factory trim values which must be added to the calculated accelerometer biases; on boot up these registers will hold
            // non-zero values. In addition, bit 0 of the lower byte must be preserved since it is used for temperature
            // compensation calculations. Accelerometer bias registers expect bias input as 2048 LSB per g, so that
            // the accelerometer biases calculated above must be divided by 8.
            int[] accel_bias_reg = { 0, 0, 0 }; // A place to hold the factory accelerometer trim biases
            data = new byte[2];
            MPU.WriteRead(new byte[] { (byte)Mpu9250Register.XA_OFFSET_H }, data); // Read factory accelerometer trim values
            accel_bias_reg[0] = ((data[0] << 8) | data[1]);
            MPU.WriteRead(new byte[] { (byte)Mpu9250Register.YA_OFFSET_H }, data);
            accel_bias_reg[1] = ((data[0] << 8) | data[1]);
            MPU.WriteRead(new byte[] { (byte)Mpu9250Register.ZA_OFFSET_H }, data);
            accel_bias_reg[2] = ((data[0] << 8) | data[1]);

            var mask = 1uL; // Define mask for temperature compensation bit 0 of lower byte of accelerometer bias registers
            int[] mask_bit = { 0, 0, 0 }; // Define array to hold mask bit for each accelerometer bias axis

            for (int i = 0; i < 3; i++)
            {
                if (((ulong)accel_bias_reg[i] & mask) != 0)
                {
                    mask_bit[i] = 0x01; // If temperature compensation bit is set, record that fact in mask_bit
                }
            }

            // Construct total accelerometer bias, including calculated average accelerometer bias from above
            accel_bias_reg[0] -= (accel_bias[0] / 8); // Subtract calculated averaged accelerometer bias scaled to 2048 LSB/g (16 g full scale)
            accel_bias_reg[1] -= (accel_bias[1] / 8);
            accel_bias_reg[2] -= (accel_bias[2] / 8);

            data = new byte[6];
            data[0] = (byte)((accel_bias_reg[0] >> 8) & 0xFF);
            data[1] = (byte)((accel_bias_reg[0]) & 0xFF);
            data[1] = (byte)(data[1] | mask_bit[0]); // preserve temperature compensation bit when writing back to accelerometer bias registers
            data[2] = (byte)((accel_bias_reg[1] >> 8) & 0xFF);
            data[3] = (byte)((accel_bias_reg[1]) & 0xFF);
            data[3] = (byte)(data[3] | mask_bit[1]); // preserve temperature compensation bit when writing back to accelerometer bias registers
            data[4] = (byte)((accel_bias_reg[2] >> 8) & 0xFF);
            data[5] = (byte)((accel_bias_reg[2]) & 0xFF);
            data[5] = (byte)(data[5] | mask_bit[2]); // preserve temperature compensation bit when writing back to accelerometer bias registers

            // Apparently this is not working for the acceleration biases in the MPU-9250
            // Are we handling the temperature correction bit properly?
            // Push accelerometer biases to hardware registers
            MPU.Write(new byte[] { (byte)Mpu9250Register.XA_OFFSET_H, data[0] });
            MPU.Write(new byte[] { (byte)Mpu9250Register.XA_OFFSET_L, data[1] });
            MPU.Write(new byte[] { (byte)Mpu9250Register.YA_OFFSET_H, data[2] });
            MPU.Write(new byte[] { (byte)Mpu9250Register.YA_OFFSET_L, data[3] });
            MPU.Write(new byte[] { (byte)Mpu9250Register.ZA_OFFSET_H, data[4] });
            MPU.Write(new byte[] { (byte)Mpu9250Register.ZA_OFFSET_L, data[5] });

            // Output scaled accelerometer biases for display in the main program
            accelBias[0] = (float)accel_bias[0] / (float)accelsensitivity;
            accelBias[1] = (float)accel_bias[1] / (float)accelsensitivity;
            accelBias[2] = (float)accel_bias[2] / (float)accelsensitivity;
        }

        /// <summary>
        /// Lese Daten
        /// </summary>
        /// <returns></returns>
        public Mpu9250Data Read()
        {
            return new Mpu9250Data()
            {
                Temperature = ReadingValue(Mpu9250DataRegister.TEMP_H) / 333.8 + 21,
                Acceleration_X = ReadingValue(Mpu9250DataRegister.ACC_X_H) * 8.0 / 32768.0 - accelBias[0]/*/ 8.192 + 26*/,
                Acceleration_Y = ReadingValue(Mpu9250DataRegister.ACC_Y_H) * 8.0 / 32768.0 - accelBias[1]/*/ 8.192 - 25*/,
                Acceleration_Z = ReadingValue(Mpu9250DataRegister.ACC_Z_H) * 8.0 / 32768.0 - accelBias[2]/*/ 8.192 - 26*/,
                AngularSpeed_X = ReadingValue(Mpu9250DataRegister.GYRO_X_H) /*/ 65.5 + 0.7*/,
                AngularSpeed_Y = ReadingValue(Mpu9250DataRegister.GYRO_Y_H) /*/ 65.5 - 2.8*/,
                AngularSpeed_Z = ReadingValue(Mpu9250DataRegister.GYRO_Z_H) /*/ 65.5 + 0.3*/
            };
        }

        /// <summary>
        /// Ließt ein Datum
        /// </summary>
        /// <param name="dataRegister">Das zu lesende Register</param>
        /// <returns></returns>
        private double ReadingValue(Mpu9250DataRegister dataRegister)
        {
            byte[] readRegister = new byte[2];
            MPU.WriteRead(new byte[] { (byte)dataRegister }, readRegister);
            byte tempH = readRegister[0];
            byte tempL = readRegister[1];
            Int16 tempRaw = (Int16)(tempH << 8 | tempL);

            double value = (double)tempRaw;
            return value;
        }
    }
}
