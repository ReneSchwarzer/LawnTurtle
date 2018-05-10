﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFA.WebServer.Html
{
    public interface IHtmlAttribute : IHtml
    {
        /// <summary>
        /// Liefert oder setzt den Namen des Attributes
        /// </summary>
        string Name { get; set; }

    }
}
