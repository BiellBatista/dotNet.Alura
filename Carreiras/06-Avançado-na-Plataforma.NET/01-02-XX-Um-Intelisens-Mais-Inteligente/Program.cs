﻿using System;

namespace _01_02_XX_Um_Intelisens_Mais_Inteligentes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menus = new string[] {
                "1. Propriedades Automáticas Somente-Leitura",
                "2. Inicializadores De Propriedade Automática",
                "3. Membros Com Corpo De Expressão",
                "4. Using Static",
                "5. Operadores Null-Condicionais",
            };

            Console.WriteLine("ÍNDICE DE PROGRAMAS");
            Console.WriteLine("===================");


            int programa = 0;
            string line;
            do
            {
                foreach (var menu in menus)
                {
                    Console.WriteLine(menu);
                }

                Console.WriteLine();
                Console.WriteLine("Escolha um programa:");

                line = Console.ReadLine();
                Int32.TryParse(line, out programa);
                switch (programa)
                {
                    case 1:
                        new R01.Programa().Main();
                        break;
                    case 2:
                        new R02.Programa().Main();
                        break;
                    case 3:
                        new R03.Programa().Main();
                        break;
                    case 4:
                        new R04.Programa().Main();
                        break;
                    case 5:
                        new R05.Programa().Main();
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("PRESSIONE UMA TECLA PARA CONTINUAR...");
                Console.ReadKey();
                Console.Clear();
            } while (line.Length > 0);
        }
    }
}