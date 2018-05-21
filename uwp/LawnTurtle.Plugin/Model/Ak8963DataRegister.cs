using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnTurtle.Plugin.Model
{
    public enum Ak8963DataRegister
    {
        XOUT_L = 0x03,  // data
        XOUT_H = 0x04,
        YOUT_L = 0x05,
        YOUT_H = 0x06,
        ZOUT_L = 0x07,
        ZOUT_H = 0x08
    }
}
