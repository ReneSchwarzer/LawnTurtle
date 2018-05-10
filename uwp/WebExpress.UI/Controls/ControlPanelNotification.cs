using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebExpress.Pages;

namespace WebExpress.UI.Controls
{
    public class ControlPanelNotification : ControlPanel
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="page">Die zugehörige Seite</param>
        /// <param name="id">Die ID</param>
        public ControlPanelNotification(IPage page, string id)
            : base(page, id)
        {
        }
    }
}
