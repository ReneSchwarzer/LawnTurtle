using LawnTurtle.Plugin.Model;
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
    public class PageMPU9250 : PageBlank
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public PageMPU9250()
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

            var mpu9250 = ViewModel.Instance.Mpu9250Data;

            Title = "MPU 9250";

            var tab = new ControlTab(this) { Layout = TypesLayoutTab.Pill, HorizontalAlignment = TypesTabHorizontalAlignment.Center };
            tab.Items.Add(new ControlLink(this) { Text = "Zentrale", Url = GetUrl(0), Icon = "fas fa-tachometer-alt" });
            tab.Items.Add(new ControlLink(this) { Text = "MPU 9250", Url = GetUrl(0, "mpu"), Class = "active", Icon = "fas fa-microchip" });

            Content.Add(tab);

            Content.Add(new ControlLine(this));

            Content.Add(new ControlText(this) { Text = "WHO AM I = " + ViewModel.Instance.Mpu9250WhoIAm });

            Content.Add(new ControlLine(this));

            Content.Add(new ControlCard
            (
                this,
                new ControlPanel
                (
                    this,
                    new ControlText(this) { Text = "X = ", Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = mpu9250.Acceleration_X.ToString("F2"), Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = "g", Format = TypesTextFormat.Span }
                ),
                new ControlPanel
                (
                    this,
                    new ControlText(this) { Text = "Y = ", Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = mpu9250.Acceleration_Y.ToString("F2"), Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = "g", Format = TypesTextFormat.Span }
                ),
                new ControlPanel
                (
                    this,
                    new ControlText(this) { Text = "Z = ", Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = mpu9250.Acceleration_Z.ToString("F2"), Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = "g", Format = TypesTextFormat.Span }
                )
            )
            { Header = "Beschleunigungsmesser" });

            Content.Add(new ControlCard
            (
                this,
                new ControlPanel
                (
                    this,
                    new ControlText(this) { Text = "X = ", Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = mpu9250.AngularSpeed_X.ToString(), Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = "°/s", Format = TypesTextFormat.Span }
                ),
                new ControlPanel
                (
                    this,
                    new ControlText(this) { Text = "Y = ", Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = mpu9250.AngularSpeed_Y.ToString(), Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = "°/s", Format = TypesTextFormat.Span }
                ),
                new ControlPanel
                (
                    this,
                    new ControlText(this) { Text = "Z = ", Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = mpu9250.AngularSpeed_Z.ToString(), Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = "°/s", Format = TypesTextFormat.Span }
                )
            )
            { Header = "Gyroskop" });

            Content.Add(new ControlCard
            (
                this,
                new ControlPanel
                (
                    this,
                    new ControlText(this) { Text = "X = ", Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = "Wert", Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = "T", Format = TypesTextFormat.Span }
                ),
                new ControlPanel
                (
                    this,
                    new ControlText(this) { Text = "Y = ", Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = "Wert", Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = "T", Format = TypesTextFormat.Span }
                ),
                new ControlPanel
                (
                    this,
                    new ControlText(this) { Text = "Z = ", Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = "Wert", Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = "T", Format = TypesTextFormat.Span }
                )
            )
            { Header = "Magnetometer" });

            Content.Add(new ControlCard
            (
                this,
                new ControlPanel
                (
                    this,
                    new ControlText(this) { Text = mpu9250.Temperature.ToString("F2"), Format = TypesTextFormat.Span },
                    new ControlText(this) { Text = "°C", Format = TypesTextFormat.Span }
                )
            )
            { Header = "Temperatur" });


            Content.Add(new ControlLine(this));

            foreach (var v in ViewModel.Instance.Mpu9250DataSet)
            {
                Content.Add(new ControlText(this) { Text = "WHO AM I = " + ViewModel.Instance.Mpu9250WhoIAm });
            }
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
