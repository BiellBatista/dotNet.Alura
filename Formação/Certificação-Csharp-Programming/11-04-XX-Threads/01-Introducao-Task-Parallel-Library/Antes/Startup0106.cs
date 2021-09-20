using System;
using System.Threading;

namespace _11_04_XX_Threads.Antes
{
    public class Startup0106 : IAulaItem
    {
        public void Executar()
        {
            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        public void Correr(int numeroCorredor)
        {
            Console.WriteLine("Corredor {0} largou", numeroCorredor);

            Thread.Sleep(1000);

            Console.WriteLine("Corredor {0} terminou", numeroCorredor);
        }
    }
}