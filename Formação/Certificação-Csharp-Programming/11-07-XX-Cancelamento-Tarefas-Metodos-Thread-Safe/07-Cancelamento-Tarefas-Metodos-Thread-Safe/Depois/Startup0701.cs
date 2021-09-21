using System;
using System.Threading;
using System.Threading.Tasks;

namespace _11_07_XX_Cancelamento_Tarefas_Metodos_Thread_Safe.Depois
{
    //Cancelar uma tarefa de execução longa
    public class Startup0701 : IAulaItem
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public void Executar()
        {
            Console.WriteLine("Tecle algo para parar o relógio");

            Task relogio = Task.Run(() => Relogio());

            Console.ReadKey();
            Console.WriteLine("O relógio parou.");

            cancellationTokenSource.Cancel();

            Console.ReadLine();
        }

        private void Relogio()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                Console.WriteLine("Tic");

                Thread.Sleep(500);

                Console.WriteLine("Tac");

                Thread.Sleep(500);
            }
        }
    }
}