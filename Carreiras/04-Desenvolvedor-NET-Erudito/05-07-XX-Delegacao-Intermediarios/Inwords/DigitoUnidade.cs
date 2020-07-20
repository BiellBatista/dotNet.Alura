using System;
using System.Collections.Generic;
using System.Text;

namespace _05_07_XX_Delegacao_Intermediarios.Inwords
{
    class DigitoUnidade : Digito
    {
        public DigitoUnidade(long numero, double posicao, Digito digitoFilho) : base(numero, posicao, digitoFilho) { }
    }
}
