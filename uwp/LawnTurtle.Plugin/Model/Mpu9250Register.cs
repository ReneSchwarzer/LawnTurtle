using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnTurtle.Plugin.Model
{
    public enum Mpu9250Register
    {
        SMPLRT_DIV = 0x19,   // SAMPLE RATE DIVIDER 
        PWR_MNGMT_1 = 0x6B,  // POWER MANAGEMENT
        PWR_MNGMT_2 = 0x6C,  // 
        CONFIG = 0x1A,       // CONFIGURATION OF FILTER
        GYRO_CONFIG = 0x1B,  // CONFIGURATION OF GYRO
        ACCEL_CONFIG = 0x1C, // CONFIGURATION OF ACCELEROMETER
        BYPASS = 0x37,
        INT_ENABLE = 0x38,
        FIFO_EN = 0x23,
        I2C_MST_CTRL = 0x24,
        USER_CTRL = 0x6A,  // Bit 7 enable DMP, bit 3 reset DMP,
        FIFO_COUNTH = 0x72,
        FIFO_R_W = 0x74,
        XG_OFFSET_H = 0x13,  // User-defined trim values for gyroscope
        XG_OFFSET_L = 0x14,
        YG_OFFSET_H = 0x15,
        YG_OFFSET_L = 0x16,
        ZG_OFFSET_H = 0x17,
        ZG_OFFSET_L = 0x18,
        XA_OFFSET_H = 0x77,
        XA_OFFSET_L = 0x78,
        YA_OFFSET_H = 0x7A,
        YA_OFFSET_L = 0x7B,
        ZA_OFFSET_H = 0x7D,
        ZA_OFFSET_L = 0x7E
    }
}
