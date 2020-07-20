using _05_06_XX_Extraindo_Incorporando_Classe.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_06_XX_Extraindo_Incorporando_Classe.Format
{
    public class TituloEleitoralFormatter : BaseFormatter
    {
        public TituloEleitoralFormatter()
            : base(DocumentFormats.TituloEleitoral, "$1/$2", DocumentFormats.TituloEleitoralUnformatted, "$1$2")
        {
        }
    }
}
