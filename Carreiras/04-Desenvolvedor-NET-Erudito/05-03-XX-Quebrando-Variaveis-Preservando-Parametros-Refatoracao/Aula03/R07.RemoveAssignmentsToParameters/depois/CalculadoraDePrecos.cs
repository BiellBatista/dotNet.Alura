using System;
using System.Collections.Generic;
using System.Text;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros_Refatoracao.R07.RemoveAssignmentsToParameters.depois
{
    class CalculadoraDePrecos
    {
        decimal GetDescontoFinal(decimal descontoInicial, int quantidade, int clienteHaQuantosAnos)
        {
            decimal resultado = descontoInicial;

            if (resultado > 50M)
            {
                resultado = 50M;
            }
            if (quantidade > 100)
            {
                resultado += 15M;
            }
            if (clienteHaQuantosAnos > 4)
            {
                resultado += 10M;
            }

            return resultado;
        }
    }
}


