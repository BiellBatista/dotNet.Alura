﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05_07_XX_Delegacao_Intermediarios_Refatoracao.Aula03.R06.SplitTemporaryVariable.antes
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
