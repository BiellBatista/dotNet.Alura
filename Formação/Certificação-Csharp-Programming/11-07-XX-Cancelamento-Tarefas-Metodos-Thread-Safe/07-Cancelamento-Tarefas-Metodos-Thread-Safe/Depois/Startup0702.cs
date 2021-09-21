using System;
using System.Threading;
using System.Threading.Tasks;

namespace _11_07_XX_Cancelamento_Tarefas_Metodos_Thread_Safe.Depois
{
    //Lançando uma exceção quando a tarefa é cancelada
    public class Startup0702 : IAulaItem
    {
        public void Executar()
        {
            Console.WriteLine("Tecle algo para parar o relógio");

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Task contagem = new Task(() => ContagemRegressiva(cancellationTokenSource.Token));

            contagem.Start();

            Console.ReadKey();

            if (contagem.IsCompleted)
            {
                Console.WriteLine("A contagem foi completada.");
            }
            else
            {
                try
                {
                    cancellationTokenSource.Cancel();
                    contagem.Wait();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A contagem foi interrompida: {0}", ex.InnerException.Message);
                }
            }

            Console.ReadLine();
        }

        private void ContagemRegressiva(CancellationToken cancellationToken)
        {
            int contador = 7;

            while (contador > 0 && !cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("contador: {0}", contador);

                Thread.Sleep(500);

                contador--;
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}