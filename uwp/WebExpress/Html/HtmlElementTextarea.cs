﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFA.WebServer.Html
{
    /// <summary>
    /// Eingabefeld (Mehrzeilig)
    /// <label for="vorname">Vorname:</label> 
    /// <input type="text" name="vorname" id="vorname" maxlength="30">
    /// </summary>
    public class HtmlElementTextarea : HtmlElement, IHtmlFormularItem
    {
        /// <summary>
        /// Liefert oder setzt den Namen des Eingabefeldes
        /// </summary>
        public string Name
        {
            get { return GetAttribute("name"); }
            set { SetAttribute("name", value); }
        }

        /// <summary>
        /// Liefert oder setzt den Wert des Eingabefeldes
        /// </summary>
        public string Value
        {
            get { return string.Join("", Elements.Where(x => x is HtmlText).Select(x => (x as HtmlText).Value)); }
            set { Elements.Clear(); Elements.Add(new HtmlText(value)); }
        }
        
        /// <summary>
        /// Liefert oder setzt die Anzahl der anzegeigten Zeilen
        /// </summary>
        public string Rows
        {
            get { return GetAttribute("rows"); }
            set { SetAttribute("rows", value); }
        }

        /// <summary>
        /// Liefert oder setzt die Anzahl der anzegeigten Spalten
        /// </summary>
        public string Cols
        {
            get { return GetAttribute("cols"); }
            set { SetAttribute("cols", value); }
        }

        /// <summary>
        /// Liefert oder setzt ob der Text umgebrochen werden soll
        ///  Mögliche Werte sind: hard, soft
        /// </summary>
        public string Wrap
        {
            get { return GetAttribute("wrap"); }
            set { SetAttribute("wrap", value); }
        }

        /// <summary>
        /// Liefert oder setzt ob das Felf schreibgeschützt ist
        /// </summary>
        public string Readonly
        {
            get { return GetAttribute("readonly"); }
            set { SetAttribute("readonly", value); }
        }

        /// <summary>
        /// Liefert oder setzt die minimale Länge
        /// </summary>
        public string MinLength
        {
            get { return GetAttribute("minlength"); }
            set { SetAttribute("minlength", value); }
        }

        /// <summary>
        /// Liefert oder setzt die maximale Länge
        /// </summary>
        public string MaxLength
        {
            get { return GetAttribute("maxlength"); }
            set { SetAttribute("maxlength", value); }
        }

        /// <summary>
        /// Liefert oder setzt ob Eingaben erzwungen werden
        /// </summary>
        public bool Required
        {
            get { return HasAttribute("required"); }
            set { if (value) { SetAttribute("required"); } else { RemoveAttribute("required"); } }
        }

        /// <summary>
        /// Liefert oder setzt ein Platzhaltertext
        /// </summary>
        public string Placeholder
        {
            get { return GetAttribute("placeholder"); }
            set { SetAttribute("placeholder", value); }
        }

        /// <summary>
        /// Liefert oder setzt ein Suchmuster, welches den Inhalt prüft
        /// </summary>
        public string Pattern 
        {
            get { return GetAttribute("pattern"); }
            set { SetAttribute("pattern", value); }
        }

        /// <summary>
        /// Liefert oder setzt den Identifizierungsname des form-Elementes mit dem es in Verbindung steht
        /// </summary>
        public string Form
        {
            get { return GetAttribute("form"); }
            set { SetAttribute("form", value); }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public HtmlElementTextarea()
            : base("textarea")
        {

        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="nodes">Der Inhalt</param>
        public HtmlElementTextarea(params IHtmlNode[] nodes)
            : this()
        {
            Elements.AddRange(nodes);
        }

        /// <summary>
        /// In String konvertieren unter Zuhilfenahme eines StringBuilder
        /// </summary>
        /// <param name="builder">Der StringBuilder</param>
        /// <param name="deep">Die Aufrufstiefe</param>
        public override void ToString(StringBuilder builder, int deep)
        {
            base.ToString(builder, deep);
        }
    }
}
