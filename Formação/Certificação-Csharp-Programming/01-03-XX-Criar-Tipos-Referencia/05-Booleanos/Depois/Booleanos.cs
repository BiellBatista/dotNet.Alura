﻿using System;

namespace _01_03_XX_Criar_Tipos_Referencia.Depois
{
    internal class Booleanos : IAulaItem
    {
        public void Executar()
        {
            //bool possuiSaldo = 1;
            bool possuiSaldo = true;

            Console.WriteLine($"possuiSaldo: {possuiSaldo}");

            int dias = DateTime.Now.Day;
            Console.WriteLine($"dias: {dias}");

            //Atribui a diasPar o valor de uma expressão booleana
            bool diasPar = (dias % 2 == 0);

            if (diasPar)
            {
                Console.WriteLine("dias é um número par");
            }
            else
            {
                Console.WriteLine("dias é um número ímpar");
            }
        }
    }
}