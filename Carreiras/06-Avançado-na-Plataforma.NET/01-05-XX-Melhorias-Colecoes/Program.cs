using System;

namespace _01_05_XX_Melhorias_Colecoes
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
                "6. Interpolação De Cadeia De Caracteres",
                "7. Expressões nameOf",
                "8. Filtros De Exceção",
                "9. Await Em Blocos Catch E Finally",
                "10. Inicializadores De Índice",
                "11. Metodos De Extensão Para Inicializadores De Coleção"
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
                    case 6:
                        new R06.Programa().Main();
                        break;
                    case 7:
                        new R07.Programa().Main();
                        break;
                    case 8:
                        new R08.Programa().Main();
                        break;
                    case 9:
                        new R09.Programa().Main();
                        break;
                    case 10:
                        new R10.Programa().Main();
                        break;
                    case 11:
                        new R11.Programa().Main();
                        break;
                    default:
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