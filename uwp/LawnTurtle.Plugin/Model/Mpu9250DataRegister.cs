using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnTurtle.Plugin.Model
{
    /// <summary>
    /// Datenregister
    /// </summary>
    public enum Mpu9250DataRegister
    {
        ACC_X_H = 0x3B,  // accelerometer X 15:8
        ACC_X_L = 0x3C,  // accelerometer X 7:0
        ACC_Y_H = 0x3D,  // accelerometer Y 15:8
        ACC_Y_L = 0x3E,  // accelerometer Y 7:0
        ACC_Z_H = 0x3F,  // accelerometer Z 15:8
        ACC_Z_L = 0x40,  // accelerometer Z 7:0
        TEMP_H = 0x41,   // temperature 15:8
        TEMP_L = 0x42,   // temperature 7:0
        GYRO_X_H = 0x43, // gyro X Z 15:8
        GYRO_X_L = 0x44, // gyro X 7:0
        GYRO_Y_H = 0x45, // gyro y Z 15:8
        GYRO_Y_L = 0x46, // gyro y 7:0
        GYRO_Z_H = 0x47, // gyro z Z 15:8
        GYRO_Z_L = 0x48  // gyro z 7:0
    }
}
