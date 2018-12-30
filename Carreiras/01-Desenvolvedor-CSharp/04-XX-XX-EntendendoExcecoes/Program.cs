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
            //try
            //{
            //    Metodo();

            //}
            //catch (DivideByZeroException)
            //{
            //    Console.WriteLine("Não é possível divisão por zero.");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.StackTrace);
            //    Console.WriteLine("Aconteceu um erro!");
            //}

            try
            {
                ContaCorrente conta = new ContaCorrente(573, 57341);
                ContaCorrente conta2 = new ContaCorrente(485, 57864);

                conta2.Transferir(-10, conta);

                conta.Depositar(150);
                Console.WriteLine(conta.Saldo);
                conta.Sacar(500);
                Console.WriteLine(conta.Saldo);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argumento com problema: " + ex.ParamName);
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException.");
                Console.WriteLine(ex.Message);
            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ocorreu uma exceção do tipo SaldoInsuficienteException.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
