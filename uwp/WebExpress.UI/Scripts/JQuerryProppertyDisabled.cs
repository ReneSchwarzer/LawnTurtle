using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.UI.Scripts
{
    public class JQuerryProppertyDisabled : JQuerryPropperty
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="selector">Der Selektor</param>
        /// <param name="value">Der Wert der Eigenschaft</param>
        public JQuerryProppertyDisabled(string selector, string value)
            : base(selector, "disabled", value)
        {
        }
    }
}
