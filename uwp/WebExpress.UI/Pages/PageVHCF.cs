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
    /// <summary>
    /// Seite, die aus einem vertikal angeordneten Kopf-, Inhalt- und Fuss-Bereich besteht
    /// </summary>
    public abstract class PageVHCF : Page
    {
        /// <summary>
        /// Liefert oder setzt den Kopf
        /// </summary>
        public ControlPanel Notification { get; private set; }

        /// <summary>
        /// Liefert oder setzt den Kopf
        /// </summary>
        public ControlPanelNavbar Head { get; private set; }

        /// <summary>
        /// Liefert oder setzt den Inhalt
        /// </summary>
        private List<Control> Content { get; set; }

        /// <summary>
        /// Liefert oder setzt die ToolBar
        /// </summary>
        public ControlToolBar ToolBar { get; protected set; }

        /// <summary>
        /// Liefert oder setzt den Inhalt
        /// </summary>
        public ControlPanelMain Main { get; private set; }

        /// <summary>
        /// Liefert oder setzt den Pfad
        /// </summary>
        public ControlBreadcrumb PathCtrl { get; private set; }

        /// <summary>
        /// Liefert oder setzt den Fuß
        /// </summary>
        public ControlFoot Foot { get; private set; }

        /// <summary>
        /// Liefert das 
        /// </summary>
        public ControlHamburgerMenu HamburgerMenu { get { return Head.HamburgerMenu; } }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public PageVHCF()
        {
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

            Content = new List<Control>();

            Notification = new ControlPanel(this, "notification") { Class = "notification" };
            Head = new ControlPanelNavbar(this, "head") { Class = "bg-dark", Role = "", Dark = true };
            ToolBar = new ControlToolBar(this, "toolbar") { Class = "toolbar" };
            Foot = new ControlFoot(this);
            Main = new ControlPanelMain(this) { Class = "" };
            PathCtrl = new ControlBreadcrumb(this);
        }

        /// <summary>
        /// Verarbeitung
        /// </summary>
        public override void Process()
        {
            base.Process();

            Content.Clear();
            Content.Add(Notification);
            Content.Add(Head);
            Content.Add(ToolBar);
            Content.Add(PathCtrl);
            Content.Add(Main);
            Content.Add(Foot);
        }

        /// <summary>
        /// In String konvertieren
        /// </summary>
        /// <returns>Das Objekt als String</returns>
        public override string ToString()
        {
            Head.Title = Title;
            PathCtrl.Path = Path;

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
