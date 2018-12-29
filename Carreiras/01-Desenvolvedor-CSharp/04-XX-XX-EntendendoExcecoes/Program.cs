using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_XX_XX_EntendendoExcecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Metodo();

            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Aconteceu um erro!");
            }

            Console.ReadLine();
        }
        //Teste com a cadeia de chamada:
        //Metodo -> TestaDivisao -> Dividir
        private static void Metodo()
        {
            TestaDivisao(2);
        }

        private static void TestaDivisao(int divisor)
        {
            try
            {
                int resultado = Dividir(10, divisor);
                Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);

            }
            catch (DivideByZeroException erro)
            {
                Console.Write(erro.Message);
                Console.Write(erro.StackTrace);
                Console.WriteLine("Não é possível fazer uma divisão por 0!");
            }
        }

        private static int Dividir(int numero, int divisor)
        {
            return numero / divisor;
        }
    }
}
