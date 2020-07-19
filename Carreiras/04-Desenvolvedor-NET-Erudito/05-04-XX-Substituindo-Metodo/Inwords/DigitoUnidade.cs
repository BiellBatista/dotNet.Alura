using System;
using System.Collections.Generic;
using System.Text;

namespace _05_04_XX_Substituindo_Metodo.Inwords
{
    class DigitoUnidade : Digito
    {
        public DigitoUnidade(long numero, double posicao, Digito digitoFilho) : base(numero, posicao, digitoFilho) { }
    }
}
