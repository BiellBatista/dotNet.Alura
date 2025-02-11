﻿using System;

namespace _01_04_XX_Classes_Metodos_Extensao.Antes
{
    internal class Delegates : IAulaItem
    {
        public void Executar()
        {
            Calculadora.Executar();
        }
    }

    internal class Calculadora
    {
        private static double Duplicar(double input)
        {
            return input * 2;
        }

        private static double Triplicar(double input)
        {
            return input * 3;
        }

        public static void Executar()
        {
            //Executa diretamente o método
            Console.WriteLine($"Duplicar(7.5): {Duplicar(7.5)}");

            //Executa diretamente o método
            Console.WriteLine($"Triplicar(7.5): {Triplicar(7.5)}");
        }
    }
}