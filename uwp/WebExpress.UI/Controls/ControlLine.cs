﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFA.WebServer.Html;
using WebExpress.Pages;

namespace WebExpress.UI.Controls
{
    public class ControlLine : Control 
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="page">Die zugehörige Seite</param>
        /// <param name="id">Die ID</param>
        public ControlLine(IPage page, string id = null)
            : base(page, id)
        {
            Init();
        }

        /// <summary>
        /// Initialisierung
        /// </summary>
        private void Init()
        {
        }

        /// <summary>
        /// In HTML konvertieren
        /// </summary>
        /// <returns>Das Control als HTML</returns>
        public override IHtmlNode ToHtml()
        {
            var classes = new List<string>();
            classes.Add(Class);

            var html = new HtmlElementHr()
            { 
                ID = ID,
                Class = string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                Style = Style, 
                Role = Role
            };

            return html;
        }
    }
}
