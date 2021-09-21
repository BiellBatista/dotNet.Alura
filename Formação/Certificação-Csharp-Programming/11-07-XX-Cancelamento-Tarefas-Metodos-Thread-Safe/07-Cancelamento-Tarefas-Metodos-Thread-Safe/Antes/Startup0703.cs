using System;
using System.Threading;
using System.Threading.Tasks;

namespace _11_07_XX_Cancelamento_Tarefas_Metodos_Thread_Safe.Antes
{
    //Cancelar uma tarefa de execução longa
    public class Startup0703 : IAulaItem
    {
        public void Executar()
        {
            Console.WriteLine("Tecle algo para parar o relógio");

            Task relogio = Task.Run(() => Relogio());

            Console.ReadKey();
            Console.WriteLine("O relógio parou.");
            Console.ReadLine();
        }

        private void Relogio()
        {
            while (true)
            {
                Console.WriteLine("Tic");

                Thread.Sleep(500);

                Console.WriteLine("Tac");

                Thread.Sleep(500);
            }
        }
    }
}