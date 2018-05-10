using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.UI.Scripts
{
    public class JQuerryIsChecked : JQuerryIs
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="selector">Der Selektor</param>
        public JQuerryIsChecked(string selector)
            : base(selector, "checked")
        {
        }
    }
}
