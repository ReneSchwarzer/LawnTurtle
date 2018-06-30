using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnTurtle.Plugin.Model
{
    /// <summary>
    /// Register
    /// siehe MPU-9250 Register Map and Descriptions Revision: 1.4
    /// https://www.invensense.com/wp-content/uploads/2015/02/MPU-9250-Register-Map.pdf
    /// </summary>
    public enum Mpu9250Register
    {
        /// <summary>
        /// Register 0 (R/W)
        /// </summary>
        SELF_TEST_X_GYRO = 0x00,
        /// <summary>
        /// Register 1 (R/W)
        /// </summary>
        SELF_TEST_Y_GYRO = 0x01,
        /// <summary>
        /// Register 2 (R/W)
        /// </summary>
        SELF_TEST_Z_GYRO = 0x02,
        /// <summary>
        /// Register 13 (R/W)
        /// </summary>
        SELF_TEST_X_ACCEL = 0x0D,
        /// <summary>
        /// Register 14 (R/W)
        /// </summary>
        SELF_TEST_Y_ACCEL = 0x0E,
        /// <summary>
        /// Register 15 (R/W)
        /// </summary>
        SELF_TEST_Z_ACCEL = 0x0F,
        /// <summary>
        /// Register 19 (R/W)
        /// User-defined trim values for gyroscope
        /// </summary>
        XG_OFFSET_H = 0x13,
        /// <summary>
        /// Register 20 (R/W)
        /// User-defined trim values for gyroscope
        /// </summary>
        XG_OFFSET_L = 0x14,
        /// <summary>
        /// Register 21 (R/W)
        /// User-defined trim values for gyroscope
        /// </summary>
        YG_OFFSET_H = 0x15,
        /// <summary>
        /// Register 22 (R/W)
        /// User-defined trim values for gyroscope
        /// </summary>
        YG_OFFSET_L = 0x16,
        /// <summary>
        /// Register 23 (R/W)
        /// User-defined trim values for gyroscope
        /// </summary>
        ZG_OFFSET_H = 0x17,
        /// <summary>
        /// Register 24 (R/W)
        /// User-defined trim values for gyroscope
        /// </summary>
        ZG_OFFSET_L = 0x18,
        /// <summary>
        /// Register 25 (R/W)
        /// SAMPLE RATE DIVIDER
        /// </summary>
        SMPLRT_DIV = 0x19,
        /// <summary>
        /// Register 26 (R/W)
        /// CONFIGURATION OF FILTER
        /// </summary>
        CONFIG = 0x1A,
        /// <summary>
        /// Register 27 (R/W)
        /// CONFIGURATION OF GYRO
        /// </summary>
        GYRO_CONFIG = 0x1B,
        /// <summary>
        /// Register 28 (R/W)
        /// CONFIGURATION OF ACCELEROMETER
        /// </summary>
        ACCEL_CONFIG = 0x1C,
        /// <summary>
        /// Register 29 (R/W)
        /// </summary>
        ACCEL_CONFIG_2 = 0x1D,
        /// <summary>
        /// Register 30 (R/W)
        /// </summary>
        LP_ACCEL_ODR = 0x1E,
        /// <summary>
        /// Register 31 (R/W)
        /// </summary>
        WOM_THR = 0x1F,
        /// <summary>
        /// Register 35 (R/W)
        /// </summary>
        FIFO_EN = 0x23,
        /// <summary>
        /// Register 36 (R/W)
        /// </summary>
        I2C_MST_CTRL = 0x24,
        /// <summary>
        /// Register 37 (R/W)
        /// </summary>
        I2C_SLV0_ADDR = 0x25,
        /// <summary>
        /// Register 38 (R/W)
        /// </summary>
        I2C_SLV0_REG = 0x26,
        /// <summary>
        /// Register 39 (R/W)
        /// </summary>
        I2C_SLV0_CTRL = 0x27,
        /// <summary>
        /// Register 40 (R/W)
        /// </summary>
        I2C_SLV1_ADDR = 0x28,
        /// <summary>
        /// Register 41 (R/W)
        /// </summary>
        I2C_SLV1_REG = 0x29,
        /// <summary>
        /// Register 42 (R/W)
        /// </summary>
        I2C_SLV1_CTRL = 0x2A,
        /// <summary>
        /// Register 43 (R/W)
        /// </summary>
        I2C_SLV2_ADDR = 0x2B,
        /// <summary>
        /// Register 44 (R/W)
        /// </summary>
        I2C_SLV2_REG = 0x2C,
        /// <summary>
        /// Register 45 (R/W)
        /// </summary>
        I2C_SLV2_CTRL = 0x2D,
        /// <summary>
        /// Register 46 (R/W)
        /// </summary>
        I2C_SLV3_ADDR = 0x2E,
        /// <summary>
        /// Register 47 (R/W)
        /// </summary>
        I2C_SLV3_REG = 0x2F,
        /// <summary>
        /// Register 48 (R/W)
        /// </summary>
        I2C_SLV3_CTRL = 0x30,
        /// <summary>
        /// Register 49 (R/W)
        /// </summary>
        I2C_SLV4_ADDR = 0x31,
        /// <summary>
        /// Register 50 (R/W)
        /// </summary>
        I2C_SLV4_REG = 0x32,
        /// <summary>
        /// Register 51 (R/W)
        /// </summary>
        I2C_SLV4_DO = 0x33,
        /// <summary>
        /// Register 52 (R/W)
        /// </summary>
        I2C_SLV4_CTRL = 0x34,
        /// <summary>
        /// Register 53 (R)
        /// </summary>
        I2C_SLV4_DI = 0x35,
        /// <summary>
        /// Register 54 (R)
        /// </summary>
        I2C_MST_STATUS = 0x36,
        /// <summary>
        /// Register 55 (R/W)
        /// </summary>
        INT_PIN_CFG = 0x37,
        /// <summary>
        /// Register 56 (R/W)
        /// </summary>
        INT_ENABLE = 0x38,
        /// <summary>
        /// Register 58 (R)
        /// </summary>
        INT_STATUS = 0x3A,
        /// <summary>
        /// Register 59 (R)
        /// </summary>
        ACCEL_XOUT_H = 0x3B,
        /// <summary>
        /// Register 60 (R)
        /// </summary>
        ACCEL_XOUT_L = 0x3C,
        /// <summary>
        /// Register 61 (R)
        /// </summary>
        ACCEL_YOUT_H = 0x3D,
        /// <summary>
        /// Register 62 (R)
        /// </summary>
        ACCEL_YOUT_L = 0x3E,
        /// <summary>
        /// Register 63 (R)
        /// </summary>
        ACCEL_ZOUT_H = 0x3F,
        /// <summary>
        /// Register 64 ()R
        /// </summary>
        ACCEL_ZOUT_L = 0x40,
        /// <summary>
        /// Register 65 (R)
        /// </summary>
        TEMP_OUT_H = 0x41,
        /// <summary>
        /// Register 66 (R)
        /// </summary>
        TEMP_OUT_L = 0x42,
        /// <summary>
        /// Register 67 (R)
        /// </summary>
        GYRO_XOUT_H = 0x43,
        /// <summary>
        /// Register 68 (R)
        /// </summary>
        GYRO_XOUT_L = 0x44,
        /// <summary>
        /// Register 69 (R)
        /// </summary>
        GYRO_YOUT_H = 0x45,
        /// <summary>
        /// Register 70 (R)
        /// </summary>
        GYRO_YOUT_L = 0x46,
        /// <summary>
        /// Register 71 (R)
        /// </summary>
        GYRO_ZOUT_H = 0x47,
        /// <summary>
        /// Register 72 (R)
        /// </summary>
        GYRO_ZOUT_L = 0x48,
        /// <summary>
        /// Register 73 (R)
        /// </summary>
        EXT_SENS_DATA_00 = 0x49,
        /// <summary>
        /// Register 74 (R)
        /// </summary>
        EXT_SENS_DATA_01 = 0x4A,
        /// <summary>
        /// Register 75 (R)
        /// </summary>
        EXT_SENS_DATA_02 = 0x4B,
        /// <summary>
        /// Register 76 (R)
        /// </summary>
        EXT_SENS_DATA_03 = 0x4C,
        /// <summary>
        /// Register 77 (R)
        /// </summary>
        EXT_SENS_DATA_04 = 0x4D,
        /// <summary>
        /// Register 78 (R)
        /// </summary>
        EXT_SENS_DATA_05 = 0x4E,
        /// <summary>
        /// Register 79 (R)
        /// </summary>
        EXT_SENS_DATA_06 = 0x4F,
        /// <summary>
        /// Register 80 (R)
        /// </summary>
        EXT_SENS_DATA_07 = 0x50,
        /// <summary>
        /// Register 81 (R)
        /// </summary>
        EXT_SENS_DATA_08 = 0x51,
        /// <summary>
        /// Register 82 (R)
        /// </summary>
        EXT_SENS_DATA_09 = 0x52,
        /// <summary>
        /// Register 83 (R)
        /// </summary>
        EXT_SENS_DATA_10 = 0x53,
        /// <summary>
        /// Register 84 (R)
        /// </summary>
        EXT_SENS_DATA_11 = 0x54,
        /// <summary>
        /// Register 85 (R)
        /// </summary>
        EXT_SENS_DATA_12 = 0x55,
        /// <summary>
        /// Register 86 (R)
        /// </summary>
        EXT_SENS_DATA_13 = 0x56,
        /// <summary>
        /// Register 87 (R)
        /// </summary>
        EXT_SENS_DATA_14 = 0x57,
        /// <summary>
        /// Register 88 (R)
        /// </summary>
        EXT_SENS_DATA_15 = 0x58,
        /// <summary>
        /// Register 89 (R)
        /// </summary>
        EXT_SENS_DATA_16 = 0x59,
        /// <summary>
        /// Register 90 (R)
        /// </summary>
        EXT_SENS_DATA_17 = 0x5A,
        /// <summary>
        /// Register 91 (R)
        /// </summary>
        EXT_SENS_DATA_18 = 0x5B,
        /// <summary>
        /// Register 92 (R)
        /// </summary>
        EXT_SENS_DATA_19 = 0x5C,
        /// <summary>
        /// Register 93 (R)
        /// </summary>
        EXT_SENS_DATA_20 = 0x5D,
        /// <summary>
        /// Register 94 (R)
        /// </summary>
        EXT_SENS_DATA_21 = 0x5E,
        /// <summary>
        /// Register 95 (R)
        /// </summary>
        EXT_SENS_DATA_22 = 0x5F,
        /// <summary>
        /// Register 96 (R)
        /// </summary>
        EXT_SENS_DATA_23 = 0x60,
        /// <summary>
        /// Register 99 (R/W)
        /// </summary>
        I2C_SLV0_DO = 0x63,
        /// <summary>
        /// Register 100 (R/W)
        /// </summary>
        I2C_SLV1_DO = 0x64,
        /// <summary>
        /// Register 101 (R/W)
        /// </summary>
        I2C_SLV2_DO = 0x65,
        /// <summary>
        /// Register 102 (R/W)
        /// </summary>
        I2C_SLV3_DO = 0x66,
        /// <summary>
        /// Register 103 (R/W)
        /// </summary>
        I2C_MST_DELAY_CTRL = 0x67,
        /// <summary>
        /// Register 104 (R/W)
        /// </summary>
        SIGNAL_PATH_RESET = 0x68,
        /// <summary>
        /// Register 105 (R/W)
        /// </summary>
        MOT_DETECT_CTRL = 0x69,
        /// <summary>
        /// Register 106 (R/W)
        /// </summary>
        USER_CTRL = 0x6A,
        /// <summary>
        /// Register 107 (R/W)
        /// POWER MANAGEMENT
        /// </summary>
        PWR_MGMT_1 = 0x6B,
        /// <summary>
        /// Register 108 (R/W)
        /// </summary>
        PWR_MGMT_2 = 0x6C,
        /// <summary>
        /// Register 114 (R/W)
        /// </summary>
        FIFO_COUNTH = 0x72,
        /// <summary>
        /// Register 115 (R/W)
        /// </summary>
        FIFO_COUNTL = 0x73,
        /// <summary>
        /// Register 116 (R/W)
        /// </summary>
        FIFO_R_W = 0x74,
        /// <summary>
        /// Register 117 (R)
        /// </summary>
        WHO_AM_I = 0x75,
        /// <summary>
        /// Register 119 (R/W)
        /// </summary>
        XA_OFFSET_H = 0x77,
        /// <summary>
        /// Register 120 (R/W)
        /// </summary>
        XA_OFFSET_L = 0x78,
        /// <summary>
        /// Register 122 (R/W)
        /// </summary>
        YA_OFFSET_H = 0x7A,
        /// <summary>
        /// Register 123 (R/W)
        /// </summary>
        YA_OFFSET_L = 0x7B,
        /// <summary>
        /// Register 125 (R/W)
        /// </summary>
        ZA_OFFSET_H = 0x7D,
        /// <summary>
        /// Register 126 (R/W)
        /// </summary>
        ZA_OFFSET_L = 0x7E
    }
}
