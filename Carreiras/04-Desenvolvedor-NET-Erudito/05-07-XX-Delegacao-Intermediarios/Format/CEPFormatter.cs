using _05_07_XX_Delegacao_Intermediarios.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_07_XX_Delegacao_Intermediarios.Format
{
    public class CEPFormatter : BaseFormatter
    {
        public CEPFormatter() 
            : base(DocumentFormats.CEP, "$1-$2", DocumentFormats.CEPUnformatted, "$1$2")
        {
        }
    }
}
