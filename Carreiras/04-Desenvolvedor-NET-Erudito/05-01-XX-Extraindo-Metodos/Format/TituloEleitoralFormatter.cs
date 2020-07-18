using _05_01_XX_Extraindo_Metodos.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_01_XX_Extraindo_Metodos.Format
{
    public class TituloEleitoralFormatter : BaseFormatter
    {
        public TituloEleitoralFormatter()
            : base(DocumentFormats.TituloEleitoral, "$1/$2", DocumentFormats.TituloEleitoralUnformatted, "$1$2")
        {
        }
    }
}
