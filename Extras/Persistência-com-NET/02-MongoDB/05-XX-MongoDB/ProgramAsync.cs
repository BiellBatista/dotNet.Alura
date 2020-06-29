using System;
using System.Threading.Tasks;

namespace _05_XX_MongoDB
{
    class ProgramAsync
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            Console.WriteLine("Esperando 10 segundos ....");
            await Task.Delay(10000);
            Console.WriteLine("Esperei 10 segundos ....");
        }
    }
}
