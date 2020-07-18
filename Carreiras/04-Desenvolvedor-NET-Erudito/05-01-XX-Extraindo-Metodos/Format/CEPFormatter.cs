using _05_01_XX_Extraindo_Metodos.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_01_XX_Extraindo_Metodos.Format
{
    public class CEPFormatter : BaseFormatter
    {
        public CEPFormatter() 
            : base(DocumentFormats.CEP, "$1-$2", DocumentFormats.CEPUnformatted, "$1$2")
        {
        }
    }
}
