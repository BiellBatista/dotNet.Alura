using System;
using System.Collections.Generic;
using System.Text;

namespace _05_08_XX_Introduzir_Metodo_Estrangeiro_Refatoracao.R16.IntroduceForeignMethod.antes
{
    class Exemplo
    {
        public Exemplo()
        {
            var data = DateTime.Today;
            var ultimoDiaDoMes = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
        }
    }
}
