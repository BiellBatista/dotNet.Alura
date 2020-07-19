using _05_02_XX_Extraindo_Variaveis_Temporarias.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_02_XX_Extraindo_Variaveis_Temporarias.Format
{
    public class TituloEleitoralFormatter : BaseFormatter
    {
        public TituloEleitoralFormatter()
            : base(DocumentFormats.TituloEleitoral, "$1/$2", DocumentFormats.TituloEleitoralUnformatted, "$1$2")
        {
        }
    }
}
