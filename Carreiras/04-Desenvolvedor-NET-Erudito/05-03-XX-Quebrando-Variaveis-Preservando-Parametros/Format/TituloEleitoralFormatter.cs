using _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Format
{
    public class TituloEleitoralFormatter : BaseFormatter
    {
        public TituloEleitoralFormatter()
            : base(DocumentFormats.TituloEleitoral, "$1/$2", DocumentFormats.TituloEleitoralUnformatted, "$1$2")
        {
        }
    }
}
