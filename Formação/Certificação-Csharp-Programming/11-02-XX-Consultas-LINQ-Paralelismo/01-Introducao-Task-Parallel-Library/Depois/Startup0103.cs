using System;
using System.Threading;
using System.Threading.Tasks;

namespace _11_02_XX_Consultas_LINQ_Paralelismo.Depois
{
    public class Startup0103 : IAulaItem
    {
        public void Executar()
        {
            //Tarefa 1: Processar uma faixa de 100 itens em paralelo
            //Tarefa 2: Completou sem interrupção?
            //Tarefa 3: Interromper quando começar a processar o valor 75
            //Tarefa 4: Quantos itens foram processados (parcialmente)?

            var resultadoLoop = Parallel.For(0, 99, (int i, ParallelLoopState state) =>
            {
                if (i == 75)
                {
                    state.Break();
                }

                Processar(i);
            });

            Console.WriteLine("Completou sem interrupção? {0}", resultadoLoop.IsCompleted);
            Console.WriteLine("Quantos itens foram processados (parcialmente)? {0}", resultadoLoop.LowestBreakIteration);
            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        private void Processar(object item)
        {
            Console.WriteLine("Começando a trabalhar com: " + item);

            Thread.Sleep(100);

            Console.WriteLine("Terminando a trabalhar com: " + item);
        }
    }
}