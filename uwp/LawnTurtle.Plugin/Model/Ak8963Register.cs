using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnTurtle.Plugin.Model
{
    public enum Ak8963Register
    {
        CNTL = 0x0A,  // Power down (0000), single-measurement (0001), self-LawnTurtle (1000) and Fuse ROM (1111) modes on bits 3:0
        ST1 = 0x02  // data ready status bit 0
    }
}
