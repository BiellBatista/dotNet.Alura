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
            catch (DivideByZeroException)
            {
                Console.WriteLine("Não é possível divisão por zero.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
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
            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);

        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Exceção com número = " + numero + "e divisor = " + divisor);
                throw; //lançando a exeção DivideByZeroException
            }
        }
    }
}
