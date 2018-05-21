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
    /// Magnetometer
    /// </summary>
    public class Ak8963
    {
        // Adressen
        private const byte ADDRESS = 0x0C;          // Address of magnetometer
        private const byte WHO_AM_I = 0x00;         // WHO AM I

        // Optionen
        private const byte MFS_16BITS = 1;          // 0.15 mG per LSB
        private const byte Mode = 0x02;             // 2 for 8 Hz, 6 for 100 Hz continuous magnetometer data read

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
        private I2cDevice Magnometer { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Ak8963()
        {
        }

        /// <summary>
        /// Bereinigung
        /// </summary>
        public void Dispose()
        {
            Magnometer.Dispose();
        }

        /// <summary>
        /// Initialisierung
        /// </summary>
        public async void InitAsync()
        {
            var settings = new I2cConnectionSettings((int)Address);
            settings.BusSpeed = I2cBusSpeed.FastMode;

            var controller = await I2cController.GetDefaultAsync();
            Magnometer = controller.GetDevice(settings);

            // First extract the factory calibration for each magnetometer axis
            Magnometer.Write(new byte[] { (byte)Ak8963Register.CNTL, 0x00 }); // Power down magnetometer 
            Thread.Sleep(10);

            Magnometer.Write(new byte[] { (byte)Ak8963Register.CNTL, 0x0F }); // Enter Fuse ROM access mode 
            Thread.Sleep(10);

            Magnometer.Write(new byte[] { (byte)Ak8963Register.CNTL, 0x00 }); // Power down magnetometer 
            Thread.Sleep(10);

            // Configure the magnetometer for continuous read and highest resolution
            // set Mscale bit 4 to 1 (0) to enable 16 (14) bit resolution in CNTL register,
            // and enable continuous mode data acquisition Mmode (bits [3:0]), 0010 for 8 Hz and 0110 for 100 Hz sample rates
            Magnometer.Write(new byte[] { (byte)Ak8963Register.CNTL, MFS_16BITS << 4 | Mode }); // Set magnetometer data resolution and sample ODR
            Thread.Sleep(10);

            var whoAmI = new byte[1];
            Magnometer.WriteRead(new byte[] { WHO_AM_I }, whoAmI); // Should return 0x48
            WHO_AM_I_Address = BitConverter.ToString(whoAmI);
        }

        /// <summary>
        /// Lese Daten
        /// </summary>
        /// <returns></returns>
        public Ak8963Data Read()
        {
            // x/y/z gyro register data, ST2 register stored here, must read ST2 at end of
            // data acquisition

            // Wait for magnetometer data ready bit to be set
            //if (Magnometer.Read(Ak8963Register.ST1) & 0x01)
            //{
            //    byte [] rawData = new byte[7];

            //    // Read the six raw data and ST2 registers sequentially into data array
            //    Magnometer.WriteRead(new byte[] { (byte)Ak8963DataRegister.XOUT_L }, 7, rawData);

            //    var c = rawData[6]; // End data read by reading ST2 register

            //    // Check if magnetic sensor overflow set, if not then report data
            //    if ((c & 0x08) > 0)
            //    {
            //        // Turn the MSB and LSB into a signed 16-bit value
            //        return new Ak8963Data()
            //        {
            //            Compass_X = ((int)rawData[1] << 8) | rawData[0],
            //            Compass_Y = ((int)rawData[3] << 8) | rawData[2],
            //            Compass_Z = ((int)rawData[5] << 8) | rawData[4],
            //        };
            //    }
            //}

            return null;
        }

        /// <summary>
        /// Ließt ein Datum
        /// </summary>
        /// <param name="dataRegister">Das zu lesende Register</param>
        /// <returns></returns>
        private double ReadingValue(Mpu9250DataRegister dataRegister)
        {
            byte[] readRegister = new byte[2];
            Magnometer.WriteRead(new byte[] { (byte)dataRegister }, readRegister);
            byte tempH = readRegister[0];
            byte tempL = readRegister[1];
            Int16 tempRaw = (Int16)(tempH << 8 | tempL);

            double value = (double)tempRaw;
            return value;
        }
    }
}
