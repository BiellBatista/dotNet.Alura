using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_02_XX_ArraysMultidimensionais
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayMultidimensional();
            JaggedArrays();

            Console.ReadLine();
        }

        internal static void ArrayMultidimensional()
        {
            //criando um array de 2D
            string[,] resultados = new string[4, 3];
            //{
            //    { "Alemanha", "Espanha", "Itália" },
            //    { "Argentina", "Holanda", "França" },
            //    { "Holanda", "Alemanha", "Alemanha" }
            //};

            resultados[0, 0] = "Alemanha";
            resultados[1, 0] = "Argentina";
            resultados[2, 0] = "Holanda";
            resultados[3, 0] = "Brasil";


            resultados[0, 1] = "Espanha";
            resultados[1, 1] = "Holanda";
            resultados[2, 1] = "Alemanha";
            resultados[3, 1] = "Uruguai";

            resultados[0, 2] = "Itália";
            resultados[1, 2] = "França";
            resultados[2, 2] = "Alemanha";
            resultados[3, 2] = "Portugal";

            //foreach (var selecao in resultados)
            //{
            //    Console.WriteLine(selecao);
            //}
            //com o método GetUpperBound, consigo pegar o tamanho de uma certa dimensão. Aqui pego o da segunda
            /*
             * Obtendo limite inferior da dimensão com GetLowerBound()
             * Obtendo limite superior da dimensão com GetUpperBound()
             */
            for (int copa = 0; copa <= resultados.GetUpperBound(1); copa++)
            {
                int ano = 2014 - copa * 4;

                Console.Write(ano.ToString().PadRight(12));
            }
            //uso o <= quando lido com indices (Length)

            Console.WriteLine();

            //com o método GetUpperBound, consigo pegar o tamanho de uma certa dimensão. Aqui pego o da primeira
            for (int posicao = 0; posicao <= resultados.GetUpperBound(0); posicao++)
            {
                for (int copa = 0; copa <= resultados.GetUpperBound(1); copa++)
                    Console.Write(resultados[posicao, copa].PadRight(12));
                Console.WriteLine();
            }
        }

        internal static void JaggedArrays()
        {
            //família 1: Família Flinstones
            //família 2: Família Simpsons
            //família 3: Família Dona Florinda

            //JAGGED ARRAY = ARRAY DENTEADO = ARRAY SERRILHADO
            string[][] familias = new string[3][];
            //{
            //    { "Fred", "Wilma", "Pedrita" },
            //    { "Home", "Marge", "Lisa", "Bard", "Maggie" },
            //    { "Florinda", "Kiko" }
            //};

            familias[0] = new string[] { "Fred", "Wilma", "Pedrita" };
            familias[1] = new string[] { "Home", "Marge", "Lisa", "Bard", "Maggie" };
            familias[2] = new string[] { "Florinda", "Kiko" };

            foreach (var familia in familias)
                Console.WriteLine(string.Join(",", familia));
            /*
             * Imprimiu:
             * Fred,Wilma,Pedrita
             * Home,Marge,Lisa,Bard,Maggie
             * Florinda,Kiko
             */
        }
    }
}
