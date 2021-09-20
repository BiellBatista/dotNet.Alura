using System;
using System.Threading;

namespace _11_04_XX_Threads.Antes
{
    public class Startup0103 : IAulaItem
    {
        public void Executar()
        {
            //Tarefa 1: Processar uma faixa de 100 itens em paralelo
            //Tarefa 2: Completou sem interrupção?
            //Tarefa 3: Interromper quando começar a processar o valor 75
            //Tarefa 4: Quantos itens foram processados (parcialmente)?

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