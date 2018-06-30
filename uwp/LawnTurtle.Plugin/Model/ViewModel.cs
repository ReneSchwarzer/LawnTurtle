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
        private Stack<Mpu9250Data> Mpu9250DataStack { get; set; }

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
                    m_this.Mpu9250DataStack = new Stack<Mpu9250Data>();
                    m_this.MPU = new Mpu9250();
                    m_this.MPU.Init();
                }

                return m_this;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Liefert oder setzt die Daten des MPU925
        /// </summary>
        private Mpu9250Data _mpu9250data = new Mpu9250Data();
        public Mpu9250Data Mpu9250Data
        {
            get
            {
                return _mpu9250data;
            }
            set
            {
                if (_mpu9250data != value)
                {
                    _mpu9250data.Temperature = value.Temperature;
                    _mpu9250data.Acceleration_X = value.Acceleration_X;
                    _mpu9250data.Acceleration_Y = value.Acceleration_Y;
                    _mpu9250data.Acceleration_Z = value.Acceleration_Z;
                    _mpu9250data.AngularSpeed_X = value.AngularSpeed_X;
                    _mpu9250data.AngularSpeed_Y = value.AngularSpeed_Y;
                    _mpu9250data.AngularSpeed_Z = value.AngularSpeed_Z;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mpu9250Data"));

                    Mpu9250DataStack.Push(value);
                    if (Mpu9250DataStack.Count > 10000)
                    {
                        Mpu9250DataStack.Pop();
                    }

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mpu9250DataSet"));
                }
            }
        }

        /// <summary>
        /// Liefert die letzten Messergebnisse des MPU9250-Sensors
        /// </summary>
        public List<Mpu9250Data> Mpu9250DataSet
        {
            get
            {
                return Mpu9250DataStack.ToList();
            }
        }

        /// <summary>
        /// Liefert oder setzt die Daten des MPU925
        /// </summary>
        public string Mpu9250WhoIAm
        {
            get
            {
                return MPU.WHO_AM_I;
            }
        }

        /// <summary>
        /// Aktualisierung der Daten
        /// </summary>
        public void Update()
        {
            Mpu9250Data = MPU.Read();
        }
    }
}
