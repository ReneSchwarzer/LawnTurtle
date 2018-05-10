using LawnTurtle.Plugin.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Register(new WorkerFile(new WebExpress.Pages.Path("", "Assets/.*"), ApplicationData.Current.LocalFolder.Path));
            Register(new WorkerPage<PageOverview>(new WebExpress.Pages.Path("", "")) { });
        }
    }
}
