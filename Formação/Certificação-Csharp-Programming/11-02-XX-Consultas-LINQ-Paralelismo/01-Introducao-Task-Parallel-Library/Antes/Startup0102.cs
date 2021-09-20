using System;
using System.Threading;

namespace _11_02_XX_Consultas_LINQ_Paralelismo.Antes
{
    public class Startup0102 : IAulaItem
    {
        public void Executar()
        {
            //MUITAS TAREFAS EM PARALELO, COM PARÂMETRO
            //=========================================
            //Tarefa 1: processar 100 itens em série
            //Tarefa 2: processar 100 itens em paralelo - percorrendo uma faixa
            //Tarefa 3: processar 100 itens em paralelo - percorrendo uma coleção

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