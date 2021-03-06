﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFA.WebServer.Html;
using WebExpress.Pages;

namespace WebExpress.UI.Controls
{
    /// <summary>
    /// Zeile der Tabelle
    /// </summary>
    public class ControlTableColumn : ControlTableRow
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="page">Die zugehörige Seite</param>
        /// <param name="id">Die ID</param>
        public ControlTableColumn(IPage page, string id)
            : base(page, id)
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

            switch (Layout)
            {
                case TypesLayoutTableRow.Primary:
                    classes.Add("table-primary");
                    break;
                case TypesLayoutTableRow.Secondary:
                    classes.Add("table-secondary");
                    break;
                case TypesLayoutTableRow.Success:
                    classes.Add("table-success");
                    break;
                case TypesLayoutTableRow.Info:
                    classes.Add("table-info");
                    break;
                case TypesLayoutTableRow.Warning:
                    classes.Add("table-warning");
                    break;
                case TypesLayoutTableRow.Danger:
                    classes.Add("table-danger");
                    break;
                case TypesLayoutTableRow.Light:
                    classes.Add("table-light");
                    break;
                case TypesLayoutTableRow.Dark:
                    classes.Add("table-dark");
                    break;
            }

            return new HtmlElementTr(from c in Cells select new HtmlElementTh(c.ToHtml()))
            {
                ID = ID,
                Class = string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };
        }
    }
}
