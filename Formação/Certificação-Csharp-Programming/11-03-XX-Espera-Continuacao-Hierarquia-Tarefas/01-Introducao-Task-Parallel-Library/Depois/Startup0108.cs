using System;
using System.Threading;
using System.Threading.Tasks;

namespace _11_03_XX_Espera_Continuacao_Hierarquia_Tarefas.Depois
{
    public class Startup0108 : IAulaItem
    {
        public void Executar()
        {
            //PROBLEMA: Criar e executar uma tarefa-mãe
            //e 10 tarefas-filhas que levam 1s cada uma para terminar.
            Task tarefaMae = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Tarefa-mãe iniciou.");

                for (int i = 0; i < 10; i++)
                {
                    int tarefaId = i;

                    Task tarefaFilha = Task.Factory.StartNew((id) =>
                        ExecutarFilha(id),
                        tarefaId,
                        TaskCreationOptions.AttachedToParent);
                }
            });

            tarefaMae.Wait();

            Console.WriteLine("Tarefa-mãe terminou.");
            Console.ReadLine();
        }

        private void ExecutarFilha(object i)
        {
            Console.WriteLine("\tTarefa-filha {0} iniciou.", i);

            Thread.Sleep(1000);

            Console.WriteLine("\tTarefa-filha {0} terminou", i);
        }
    }
}