using System;
using System.Collections.Generic;
using System.Text;

namespace _05_06_XX_Extraindo_Incorporando_Classe.Inwords
{
    class DigitoUnidade : Digito
    {
        public DigitoUnidade(long numero, double posicao, Digito digitoFilho) : base(numero, posicao, digitoFilho) { }
    }
}
