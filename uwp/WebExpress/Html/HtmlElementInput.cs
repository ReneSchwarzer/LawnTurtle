﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFA.WebServer.Html
{
    /// <summary>
    /// Eingabefeld
    /// <label for="vorname">Vorname:</label> 
    /// <input type="text" name="vorname" id="vorname" maxlength="30">
    /// </summary>
    public class HtmlElementInput : HtmlElement, IHtmlFormularItem
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
        /// Liefert oder setzt den Mindestwert
        /// </summary>
        public string Type
        {
            get { return GetAttribute("type"); }
            set { SetAttribute("type", value); }
        }

        /// <summary>
        /// Liefert oder setzt den Wert des Eingabefeldes
        /// </summary>
        public string Value
        {
            get { return GetAttribute("value"); }
            set { SetAttribute("value", value.Replace("'", "&#39;").Replace("\"", "&#34;")); }
        }
        
        /// <summary>
        /// Liefert oder setzt die Zeichenlänge bei text, search, tel, url, email, oder password 
        /// Falls kein Wert angegeben wird, wird der Standardwert 20 verwendet.
        /// </summary>
        public string Size
        {
            get { return GetAttribute("size"); }
            set { SetAttribute("size", value); }
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
        /// Liefert oder setzt ob das Eingabefeld verwendet werden kann
        /// </summary>
        public bool Disabled
        {
            get { return HasAttribute("disabled"); }
            set { if (value) { SetAttribute("disabled"); } else { RemoveAttribute("disabled"); } }
        }
        
        /// <summary>
        /// Liefert oder setzt den Mindestwert
        /// </summary>
        public string Min
        {
            get { return GetAttribute("min"); }
            set { SetAttribute("min", value); }
        }

        /// <summary>
        /// Liefert oder setzt den Maximalenwert
        /// </summary>
        public string Max
        {
            get { return GetAttribute("max"); }
            set { SetAttribute("max", value); }
        }

        /// <summary>
        /// Liefert oder setzt die Schrittweite bei numerische, Datums- oder Zeitangaben 
        /// </summary>
        public string Step
        {
            get { return GetAttribute("step"); }
            set { SetAttribute("step", value); }
        }

        /// <summary>
        /// Liefert oder setzt den Namen einer Liste (datalist)
        /// </summary>
        public string List
        {
            get { return GetAttribute("list"); }
            set { SetAttribute("list", value); }
        }
        
        /// <summary>
        /// Liefert oder setzt ob mehrfacheingaben von Datei-Uploads und Emaileingaben möglich sind
        /// </summary>
        public string Multiple
        {
            get { return GetAttribute("multiple"); }
            set { SetAttribute("multiple", value); }
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
        /// Liefert oder setzt ob eine Auswahl erfolt (nur bei Radio- und Check)
        /// </summary>
        public bool Checked
        {
            get { return HasAttribute("checked"); }
            set { if (value) { SetAttribute("checked"); } else { RemoveAttribute("checked"); } }
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
        /// Liefert oder setzt ein Platzhaltertext
        /// </summary>
        public string Placeholder
        {
            get { return GetAttribute("placeholder"); }
            set { SetAttribute("placeholder", value); }
        }

        /// <summary>
        /// Liefert oder setzt die Eingabemethode (hilft mobilen Geräten, die richtige Tastatur-(belegung) zu wählen)
        /// </summary>
        public string Inputmode 
        {
            get { return GetAttribute("inputmode"); }
            set { SetAttribute("inputmode", value); }
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
        public HtmlElementInput()
            : base("input")
        {
            CloseTag = false;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="nodes">Der Inhalt</param>
        public HtmlElementInput(params IHtmlNode[] nodes)
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
