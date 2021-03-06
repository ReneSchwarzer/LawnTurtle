﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFA.WebServer.Html;
using WebExpress.Pages;

namespace WebExpress.UI.Controls
{
    public class ControlTable : Control
    {
        /// <summary>
        /// Liefert oder setzt das Layout der Spaltenüberschrift
        /// </summary>
        public TypesLayoutTableRow ColumnLayout { get; set; }

        /// <summary>
        /// Liefert oder setzt die Spalten
        /// </summary>
        public ControlTableColumn Columns { get; private set; }

        /// <summary>
        /// Liefert oder setzt die Zeilen
        /// </summary>
        public List<ControlTableRow> Rows { get; private set; }

        /// <summary>
        /// Liefert oder setzt die Responsive-Eigenschaft
        /// </summary>
        public bool Responsive { get; set; }

        /// <summary>
        /// Liefert oder setzt die Striped-Eigenschaft
        /// </summary>
        public bool Striped { get; set; }

        /// <summary>
        /// Liefert oder setzt das die Tabelle gedreht wird
        /// </summary>
        public bool Reflow { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="page">Die zugehörige Seite</param>
        /// <param name="id">Die ID</param>
        public ControlTable(IPage page, string id = null)
            : base(page, id)
        {
            Init();
        }

        /// <summary>
        /// Initialisierung
        /// </summary>
        private void Init()
        {
            Class = "";
            Striped = true;
            Columns = new ControlTableColumn(Page, null);
            Rows = new List<ControlTableRow>();
        }

        /// <summary>
        /// Fügt eine Spalte hinzu
        /// </summary>
        /// <param name="name">Name der Spalte</param>
        /// <returns></returns>
        public virtual void AddColumn(string name)
        {
            Columns.Cells.Add(new ControlText(Page) { Text = name });
        }

        /// <summary>
        /// Fügt eine Zeile hinzu
        /// </summary>
        /// <param name="cells">Die Zellen der Zeile</param>
        /// <param name="cssClass">Die Css-Klasse</param>
        public void AddRow(Control[] cells, string cssClass = null)
        {
            var r = new ControlTableRow(Page, null) { Class = cssClass };
            r.Cells.AddRange(cells);

            Rows.Add(r);
        }

        /// <summary>
        /// Fügt eine Zeile hinzu
        /// </summary>
        /// <param name="cells">Die Zellen der Zeile</param>
        /// <param name="layout">Das Layout</param>
        /// <param name="cssClass">Die Css-Klasse</param>
        public void AddRow(Control[] cells, TypesLayoutTableRow layout, string cssClass = null)
        {
            var r = new ControlTableRow(Page, null) { Class = cssClass, Layout = layout };
            r.Cells.AddRange(cells);

            Rows.Add(r);
        }

        /// <summary>
        /// In HTML konvertieren
        /// </summary>
        /// <returns>Das Control als HTML</returns>
        public override IHtmlNode ToHtml()
        {
            Columns.Layout = ColumnLayout;

            var classes = new List<string>();
            classes.Add(Class);
            classes.Add("table");

            if (Striped)
            {
                classes.Add("table-striped");
            }

            if (Responsive)
            {
                classes.Add("table-responsive");
            }

            if (Reflow)
            {
                classes.Add("table-reflow");
            }

            var html = new HtmlElementTable()
            {
                ID = ID,
                Class = string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                Style = Style
            };

            html.Columns = Columns.ToHtml() as HtmlElementTr;
            html.Rows.AddRange(from x in Rows select x.ToHtml() as HtmlElementTr);
            
            return html;
        }
    }
}
