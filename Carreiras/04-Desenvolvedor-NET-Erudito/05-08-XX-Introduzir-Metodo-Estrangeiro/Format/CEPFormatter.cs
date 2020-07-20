using _05_08_XX_Introduzir_Metodo_Estrangeiro.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_08_XX_Introduzir_Metodo_Estrangeiro.Format
{
    public class CEPFormatter : BaseFormatter
    {
        public CEPFormatter() 
            : base(DocumentFormats.CEP, "$1-$2", DocumentFormats.CEPUnformatted, "$1$2")
        {
        }
    }
}
