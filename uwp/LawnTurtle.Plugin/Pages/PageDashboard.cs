using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Pages;
using WebExpress.UI.Controls;
using WebExpress.UI.Pages;

namespace LawnTurtle.Plugin.Pages
{
    public class PageDashboard : PageBlank
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public PageDashboard()
        {
            //Favicon = "/assets/PlanExpress.ico";
            //CssLink.Add("/assets/css/express.css");
        }

        /// <summary>
        /// Initialisierung
        /// </summary>
        public override void Init()
        {
            base.Init();
        }

        /// <summary>
        /// Verarbeitung
        /// </summary>
        public override void Process()
        {
            base.Process();

            Title = "Überblick";

            var tab = new ControlTab(this) { Layout = TypesLayoutTab.Pill, HorizontalAlignment = TypesTabHorizontalAlignment.Center };
            tab.Items.Add(new ControlLink(this) { Text = "Zentrale", Url = GetUrl(0), Class = "active", Icon = "fas fa-tachometer-alt" });
            tab.Items.Add(new ControlLink(this) { Text = "MPU 9250", Url = GetUrl(0, "mpu"), Icon = "fas fa-microchip" });

            Content.Add(tab);

            Content.Add(new ControlLine(this));
        }

        /// <summary>
        /// In String konvertieren
        /// </summary>
        /// <returns>Das Objekt als String</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
