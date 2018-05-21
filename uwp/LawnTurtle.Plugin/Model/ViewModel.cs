using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnTurtle.Plugin.Model
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Mpu9250 MPU { get; set; }

        /// <summary>
        /// Instanz des einzigen Modells
        /// </summary>
        private static ViewModel m_this = null;

        /// <summary>
        /// Lifert die einzige Instanz der Modell-Klasse
        /// </summary>
        public static ViewModel Instance
        {
            get
            {
                if (m_this == null)
                {
                    m_this = new ViewModel();
                    m_this.MPU = new Mpu9250();
                    m_this.MPU.InitAsync();
                }

                return m_this;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Bestimmt ob das Viewmodell vollständig inizalisiert ist
        /// </summary>
        private Mpu9250Data _data = new Mpu9250Data();
        public Mpu9250Data Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (_data != value)
                {
                    _data.Temperature = value.Temperature;
                    _data.Acceleration_X = value.Acceleration_X;
                    _data.Acceleration_Y = value.Acceleration_Y;
                    _data.Acceleration_Z = value.Acceleration_Z;
                    _data.AngularSpeed_X = value.AngularSpeed_X;
                    _data.AngularSpeed_Y = value.AngularSpeed_Y;
                    _data.AngularSpeed_Z = value.AngularSpeed_Z;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Data"));
                }
            }
        }

        public void Update()
        {
            Data = MPU.Read();
        }
    }
}
