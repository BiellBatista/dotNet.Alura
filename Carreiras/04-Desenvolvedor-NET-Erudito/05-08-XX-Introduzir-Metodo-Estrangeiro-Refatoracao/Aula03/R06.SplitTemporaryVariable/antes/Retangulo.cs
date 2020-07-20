using System;
using System.Collections.Generic;
using System.Text;

namespace _05_08_XX_Introduzir_Metodo_Estrangeiro_Refatoracao.Aula03.R06.SplitTemporaryVariable.antes
{
    class Retangulo
    {
        public Retangulo(double altura, double largura)
        {
            double temp = 2 * (altura + largura);
            System.Console.WriteLine($"Perímetro: {temp}");

            temp = altura * largura;
            System.Console.WriteLine($"Área: {temp}");
        }
    }
}
