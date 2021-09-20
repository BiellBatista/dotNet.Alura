using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace _11_03_XX_Espera_Continuacao_Hierarquia_Tarefas.Depois
{
    public class Startup0106 : IAulaItem
    {
        public void Executar()
        {
            Console.WriteLine("Número de threads:");
            Console.WriteLine(Process.GetCurrentProcess().Threads.Count);

            Task[] tarefas = new Task[10];

            for (int i = 0; i < 10; i++)
            {
                //guardar o valor de i numa variável local!
                int numeroCorredor = i;

                Task tarefa = Task.Run(() => Correr(numeroCorredor));

                tarefas[i] = tarefa;
            }

            Task.WaitAll(tarefas);

            Console.WriteLine("Número de threads:");
            Console.WriteLine(Process.GetCurrentProcess().Threads.Count);
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