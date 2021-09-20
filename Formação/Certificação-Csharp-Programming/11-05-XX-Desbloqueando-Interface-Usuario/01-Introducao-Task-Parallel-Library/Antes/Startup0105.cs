using System;
using System.Threading;

namespace _11_05_XX_Desbloqueando_Interface_Usuario.Antes
{
    public class Startup0105 : IAulaItem
    {
        public void Executar()
        {
            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        public void ExecutaTrabalho(int item)
        {
            Console.WriteLine("Trabalho iniciado: {0}", item);

            Thread.Sleep(2000);

            Console.WriteLine("Trabalho terminado: {0}", item);
            Console.WriteLine();
        }

        public int CalcularResultado(int numero1, int numero2)
        {
            Console.WriteLine("Trabalho iniciado");

            Thread.Sleep(2000);

            Console.WriteLine("Trabalho terminado");
            Console.WriteLine();

            return numero1 + numero2;
        }
    }
}