using _05_02_XX_Extraindo_Variaveis_Temporarias.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_02_XX_Extraindo_Variaveis_Temporarias.Format
{
    public class CEPFormatter : BaseFormatter
    {
        public CEPFormatter() 
            : base(DocumentFormats.CEP, "$1-$2", DocumentFormats.CEPUnformatted, "$1$2")
        {
        }
    }
}
