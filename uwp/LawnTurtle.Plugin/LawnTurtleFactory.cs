using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress;
using WebExpress.Plugins;

namespace LawnTurtle.Plugin
{
    public class LawnTurtleFactory : PluginFactory
    {
        /// <summary>
        /// Erstellt eine neue Instanz eines Prozesszustandes
        /// </summary>
        /// <param name="host">Der Benutzer</param>
        /// <param name="configFileName">Der Dateiname der Konfiguration oder null</param>
        /// <returns>Die Instanz des Prozesszustandes</returns>
        public override IPlugin Create(IHost host, string configFileName)
        {
            return Create<LawnTurtle>(host, configFileName);
        }
    }
}
