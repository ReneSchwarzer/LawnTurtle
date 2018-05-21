using LawnTurtle.Plugin.Model;
using LawnTurtle.Plugin.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Pages;
using WebExpress.Workers;
using Windows.Storage;

namespace LawnTurtle.Plugin
{
    public class LawnTurtle : WebExpress.Plugins.Plugin
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public LawnTurtle()
        : base("LawnTurtle")
        {
            Init(null);
        }

        /// <summary>
        /// Initialisierung des Prozesszustandes. Hier können z.B. verwaltete Ressourcen geladen werden. 
        /// </summary>
        /// <param name="configFileName">Der Dateiname der Konfiguration oder null</param>
        public override void Init(string configFileName)
        {
            Register(new WorkerFile(new Path("", "Assets/.*"), ApplicationData.Current.LocalFolder.Path));

            var root = new VariationPath("dashboard", new PathItem("Zentrale"));
            var mpu = new VariationPath(root, "mpu", new PathItem("MPU 9250", "mpu"));

            root.GetUrls("Zentrale").ForEach(x => Register(new WorkerPage<PageDashboard>(x) { }));
            mpu.GetUrls("MPU 9250").ForEach(x => Register(new WorkerPage<PageMPU9250>(x) { }));

            Task.Run(()=> { Run(); });
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, nachdem das Fenster aktiv ist.
        /// </summary>
        private void Run()
        {
            var timer = new Timer();

            // Loop
            while (true)
            {
                timer.Update();

                Update(timer);
            }
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, nachdem das Fenster aktiv ist.
        /// </summary>
        private void Update(Timer timer)
        {
            ViewModel.Instance.Update();
        }
    }
}
