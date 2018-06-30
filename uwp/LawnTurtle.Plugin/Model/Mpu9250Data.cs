using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnTurtle.Plugin.Model
{
    public class Mpu9250Data
    {
        /// <summary>
        /// Liefert oder setzt die Temperatur
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// Liefert oder setzt
        /// </summary>
        public double Acceleration_X { get; set; }

        /// <summary>
        /// Liefert oder setzt
        /// </summary>
        public double Acceleration_Y { get; set; }

        /// <summary>
        /// Liefert oder setzt
        /// </summary>
        public double Acceleration_Z { get; set; }

        /// <summary>
        /// Liefert oder setzt
        /// </summary>
        public double AngularSpeed_X { get; set; }

        /// <summary>
        /// Liefert oder setzt 
        /// </summary>
        public double AngularSpeed_Y { get; set; }

        /// <summary>
        /// Liefert oder setzt
        /// </summary>
        public double AngularSpeed_Z { get; set; }
    }
}
