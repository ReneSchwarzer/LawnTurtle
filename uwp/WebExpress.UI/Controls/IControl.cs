using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TFA.WebServer.Html;
using WebExpress.Pages;

namespace WebExpress.UI.Controls
{
    public interface IControl
    {
        /// <summary>
        /// Liefert oder setzt die zugehörige Seite
        /// </summary>
        IPage Page { get; }
        
        /// <summary>
        /// Liefert oder setzt die ID
        /// </summary>
        string ID { get; }

        /// <summary>
        /// Liefert oder setzt die Css-Klasse
        /// </summary>
        string Class { get; set; }

        /// <summary>
        /// Liefert oder setzt die Css-Style
        /// </summary>
        string Style { get; set; }

        /// <summary>
        /// In HTML konvertieren
        /// </summary>
        /// <returns>Das Control als HTML</returns>
        IHtmlNode ToHtml();
    }
}
