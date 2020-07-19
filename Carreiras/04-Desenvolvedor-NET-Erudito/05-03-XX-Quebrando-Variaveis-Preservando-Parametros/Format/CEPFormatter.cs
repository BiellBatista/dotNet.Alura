using _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Format
{
    public class CEPFormatter : BaseFormatter
    {
        public CEPFormatter() 
            : base(DocumentFormats.CEP, "$1-$2", DocumentFormats.CEPUnformatted, "$1$2")
        {
        }
    }
}
