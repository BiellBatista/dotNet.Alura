using _05_04_XX_Substituindo_Metodo.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_04_XX_Substituindo_Metodo.Format
{
    public class TituloEleitoralFormatter : BaseFormatter
    {
        public TituloEleitoralFormatter()
            : base(DocumentFormats.TituloEleitoral, "$1/$2", DocumentFormats.TituloEleitoralUnformatted, "$1$2")
        {
        }
    }
}
