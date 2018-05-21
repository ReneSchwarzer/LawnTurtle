using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnTurtle.Plugin.Model
{
    public class Mpu9250Data : INotifyPropertyChanged
    {
        /// <summary>
        /// Liefert oder setzt die Temperatur
        /// </summary>
        private double temperature = 0;
        public double Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (temperature != value)
                {
                    temperature = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Temperature"));
                }
            }
        }

        /// <summary>
        /// Liefert oder setzt
        /// </summary>
        private double acceleration_X = 0;
        public double Acceleration_X
        {
            get
            {
                return acceleration_X;
            }
            set
            {
                if (acceleration_X != value)
                {
                    acceleration_X = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Acceleration_X"));
                }
            }
        }

        /// <summary>
        /// Liefert oder setzt
        /// </summary>
        private double acceleration_Y = 0;
        public double Acceleration_Y
        {
            get
            {
                return acceleration_Y;
            }
            set
            {
                if (acceleration_Y != value)
                {
                    acceleration_Y = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Acceleration_Y"));
                }
            }
        }

        /// <summary>
        /// Liefert oder setzt
        /// </summary>
        private double acceleration_Z = 0;
        public double Acceleration_Z
        {
            get
            {
                return acceleration_Z;
            }
            set
            {
                if (acceleration_Z != value)
                {
                    acceleration_Z = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Acceleration_Z"));
                }
            }
        }

        /// <summary>
        /// Liefert oder setzt
        /// </summary>
        private double angularSpeed_X = 0;
        public double AngularSpeed_X
        {
            get
            {
                return angularSpeed_X;
            }
            set
            {
                if (angularSpeed_X != value)
                {
                    angularSpeed_X = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AngularSpeed_X"));
                }
            }
        }

        /// <summary>
        /// Liefert oder setzt 
        /// </summary>
        private double angularSpeed_Y = 0;
        public double AngularSpeed_Y
        {
            get
            {
                return angularSpeed_Y;
            }
            set
            {
                if (angularSpeed_Y != value)
                {
                    angularSpeed_Y = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AngularSpeed_Y"));
                }
            }
        }

        /// <summary>
        /// Liefert oder setzt
        /// </summary>
        private double angularSpeed_Z = 0;
        public double AngularSpeed_Z
        {
            get
            {
                return angularSpeed_Z;
            }
            set
            {
                if (angularSpeed_Z != value)
                {
                    angularSpeed_Z = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AngularSpeed_Z"));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
