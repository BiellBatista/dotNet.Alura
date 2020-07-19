using _05_05_XX_Movendo_Metodo_Campo.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_05_XX_Movendo_Metodo_Campo.Format
{
    public class TituloEleitoralFormatter : BaseFormatter
    {
        public TituloEleitoralFormatter()
            : base(DocumentFormats.TituloEleitoral, "$1/$2", DocumentFormats.TituloEleitoralUnformatted, "$1$2")
        {
        }
    }
}
