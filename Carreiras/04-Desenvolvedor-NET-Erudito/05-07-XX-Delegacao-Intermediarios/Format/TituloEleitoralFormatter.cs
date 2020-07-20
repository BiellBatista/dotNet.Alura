using _05_07_XX_Delegacao_Intermediarios.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_07_XX_Delegacao_Intermediarios.Format
{
    public class TituloEleitoralFormatter : BaseFormatter
    {
        public TituloEleitoralFormatter()
            : base(DocumentFormats.TituloEleitoral, "$1/$2", DocumentFormats.TituloEleitoralUnformatted, "$1$2")
        {
        }
    }
}
