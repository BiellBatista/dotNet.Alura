using _05_05_XX_Movendo_Metodo_Campo.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_05_XX_Movendo_Metodo_Campo.Format
{
    public class CEPFormatter : BaseFormatter
    {
        public CEPFormatter() 
            : base(DocumentFormats.CEP, "$1-$2", DocumentFormats.CEPUnformatted, "$1$2")
        {
        }
    }
}
