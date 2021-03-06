﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.UI.Controls
{
    public class ValidationResult
    { 
        /// <summary>
        /// Liefert oder setzt den Typ des Fehlers
        /// </summary>
        public TypesInputValidity Type { get; set; }

        /// <summary>
        /// Liefert oder setzt den Fehlertext
        /// </summary>
        public string Text { get; set; }
    }
}
