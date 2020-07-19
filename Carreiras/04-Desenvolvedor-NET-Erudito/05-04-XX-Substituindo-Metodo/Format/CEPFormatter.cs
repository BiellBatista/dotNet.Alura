﻿using _05_04_XX_Substituindo_Metodo.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_04_XX_Substituindo_Metodo.Format
{
    public class CEPFormatter : BaseFormatter
    {
        public CEPFormatter() 
            : base(DocumentFormats.CEP, "$1-$2", DocumentFormats.CEPUnformatted, "$1$2")
        {
        }
    }
}
