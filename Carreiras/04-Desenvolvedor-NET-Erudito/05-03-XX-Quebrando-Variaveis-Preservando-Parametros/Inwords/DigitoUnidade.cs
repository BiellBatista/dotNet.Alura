using System;
using System.Collections.Generic;
using System.Text;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Inwords
{
    class DigitoUnidade : Digito
    {
        public DigitoUnidade(long numero, double posicao, Digito digitoFilho) : base(numero, posicao, digitoFilho) { }
    }
}
