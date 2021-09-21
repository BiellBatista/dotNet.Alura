using System;

namespace _11_07_XX_Cancelamento_Tarefas_Metodos_Thread_Safe.Antes
{
    //Task Parallel com Parallel.For / PLINQ / Tasks
    public class Startup0101 : IAulaItem
    {
        public void Executar()
        {
            //TAREFA 1: Cozinhar e refogar EM SÉRIE
            //TAREFA 2: Cozinhar e refogar EM PARALELO
            //TAREFA 3: Medir o tempo dos 2 procedimentos

            Console.WriteLine(
                "Retire do fogo e ponha o molho sobre o macarrão. " +
                "Bom apetite! " +
                "Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        private void CozinharMacarrao()
        {
            Console.WriteLine("Cozinhando macarrão...");
            Console.WriteLine("Macarrão já está cozido!");
            Console.WriteLine();
        }

        private void RefogarMolho()
        {
            Console.WriteLine("Refogando molho...");
            Console.WriteLine("Molho já está refogado!");
            Console.WriteLine();
        }
    }
}