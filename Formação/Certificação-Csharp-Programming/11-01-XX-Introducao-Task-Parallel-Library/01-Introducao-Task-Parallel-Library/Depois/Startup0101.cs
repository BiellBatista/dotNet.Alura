using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace _11_01_XX_Introducao_Task_Parallel_Library.Depois
{
    //Task Parallel com Parallel.For / PLINQ / Tasks
    public class Startup0101 : IAulaItem
    {
        public void Executar()
        {
            //TAREFA 1: Cozinhar e refogar EM SÉRIE
            //TAREFA 2: Cozinhar e refogar EM PARALELO
            //TAREFA 3: Medir o tempo dos 2 procedimentos
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            CozinharMacarrao();
            RefogarMolho();
            stopwatch.Stop();

            Console.WriteLine("Tempo decorrido: {0} segundos", stopwatch.ElapsedMilliseconds / 1000.0);

            stopwatch.Restart();

            Parallel.Invoke(() => CozinharMacarrao(), () => RefogarMolho());
            stopwatch.Stop();

            Console.WriteLine("Tempo decorrido: {0} segundos", stopwatch.ElapsedMilliseconds / 1000.0);

            Console.WriteLine(
                "Retire do fogo e ponha o molho sobre o macarrão. " +
                "Bom apetite! " +
                "Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        private void CozinharMacarrao()
        {
            Console.WriteLine("Cozinhando macarrão...");

            Thread.Sleep(1000);

            Console.WriteLine("Macarrão já está cozido!");
            Console.WriteLine();
        }

        private void RefogarMolho()
        {
            Console.WriteLine("Refogando molho...");

            Thread.Sleep(2000);

            Console.WriteLine("Molho já está refogado!");
            Console.WriteLine();
        }
    }
}