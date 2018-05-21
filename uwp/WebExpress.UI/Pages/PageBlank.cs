using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFA.WebServer.Html;
using WebExpress.Pages;
using WebExpress.UI.Controls;

namespace WebExpress.UI.Pages
{
    public class PageBlank : Page
    {
        /// <summary>
        /// Liefert oder setzt den Inhalt
        /// </summary>
        protected List<Control> Content { get; private set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public PageBlank()
        {
            Content = new List<Control>();

            CssLink.Add("/Assets/css/fontawesome.css");
            CssLink.Add("/Assets/css/bootstrap.min.css");
            CssLink.Add("/Assets/css/express.css");
            CssLink.Add("/Assets/css/express.form.css");
            CssLink.Add("/Assets/css/fa-solid.css");
            CssLink.Add("/Assets/css/summernote-bs4.css");

            AddScriptLink("/Assets/jquery-3.3.1.min.js");
            AddScriptLink("/Assets/popper.min.js");
            AddScriptLink("/Assets/bootstrap.min.js");
        }

        /// <summary>
        /// Initialisierung
        /// </summary>
        public override void Init()
        {
            base.Init();
        }

        /// <summary>
        /// In String konvertieren
        /// </summary>
        /// <returns>Das Objekt als String</returns>
        public override string ToString()
        {
            var html = new HtmlElementHtml();
            html.Head.Title = Title;
            html.Head.Styles = Style;
            html.Head.CssLinks = CssLink;
            html.Head.Favicon = Favicon;
            html.Head.Meta = Meta;
            html.Body.Elements.AddRange(Content.Select(x => x.ToHtml()));

            return html.ToString();
        }
    }
}
