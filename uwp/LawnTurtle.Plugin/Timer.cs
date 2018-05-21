using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnTurtle.Plugin
{
    /// <summary>
    /// Klasse für die zeitliche Steuerung
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Verstrichene Ticks seit dem vorherigen Update-Aufruf.
        /// </summary>
        public long ElapsedTicks { get; private set; }

        /// <summary>
        /// Verstrichene Zeit (in s) seit dem vorherigen Update-Aufruf.
        /// </summary>
        public double ElapsedSeconds { get; private set; }

        /// <summary>
        /// Verstrichene Zeit (im ms) seit dem vorherigen Update-Aufruf.
        /// </summary>
        public double ElapsedMilliseconds { get; private set; }

        /// <summary>
        /// Ticks seit dem Programmstart.
        /// </summary>
        /// <returns></returns>
        public long TotalTicks { get { return (CurrentTime - StartTime).Ticks; } }

        /// <summary>
        /// Gesamtzeit seit dem Programmstart.
        /// </summary>
        public double TotalSeconds { get { return (CurrentTime - StartTime).TotalSeconds; } }

        /// <summary>
        /// Die Startzeit
        /// </summary>
        private DateTime StartTime { get; set; }

        /// <summary>
        /// Die letzte gemessene Zeit
        /// </summary>
        private DateTime LastTime { get; set; }

        /// <summary>
        /// Die aktuell gemessene Zeit
        /// </summary>
        public DateTime CurrentTime { get { return DateTime.Now; } }

        /// <summary>
        /// Konstruktor
        /// </summary>
		public Timer()
        {
            ResetElapsedTime();
        }

        /// <summary>
        /// Nach einer absichtlichen Zeitsteuerungsdiskontinuität (z. B. ein blockierender EA-Vorgang)
        /// Dies aufrufen, um zu vermeiden, dass die feste Zeitschrittlogik eine Folge von aufholenden Aktualisierungsaufrufen versucht.
        /// </summary>
        public void ResetElapsedTime()
        {
            StartTime = DateTime.Now;
            LastTime = StartTime;

            Update();
        }

        /// <summary>
        /// Zeitgeberzustand aktualisieren, dabei die angegebene Aktualisierungsfunktion entsprechend viele Male aufrufen.
        /// </summary>
        public void Update()
        {
            // Die aktuelle Uhrzeit abfragen.
            var currenttime = CurrentTime;

            // Differenz zur letzten Zeitabfrage 
            var timeDelta = currenttime - LastTime;

            ElapsedTicks = timeDelta.Ticks;
            ElapsedSeconds = timeDelta.TotalSeconds;
            ElapsedMilliseconds = timeDelta.TotalMilliseconds;

            LastTime = currenttime;
        }
    }
}
