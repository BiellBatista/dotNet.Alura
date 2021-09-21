using System;
using System.Threading.Tasks;

namespace _11_07_XX_Cancelamento_Tarefas_Metodos_Thread_Safe.Depois
{
    public class Startup0107 : IAulaItem
    {
        public void Executar()
        {
            Task tarefa = Task.Run(() => Ola());

            tarefa.ContinueWith((tarefaAnterior) => Mundo(), TaskContinuationOptions.NotOnFaulted);
            tarefa.ContinueWith((tarefaAnterior) => Erro(tarefaAnterior), TaskContinuationOptions.OnlyOnFaulted);

            Console.ReadLine();
        }

        private static void Mundo()
        {
            Console.WriteLine("Mundo");
        }

        private static void Ola()
        {
            Console.WriteLine("Olá");

            throw new ApplicationException("Opa! Ocorreu erro no método Olá");
        }

        private static void Erro(Task tarefaAnterior)
        {
            var excecoes = tarefaAnterior.Exception.InnerExceptions;

            foreach (var excecao in excecoes)
            {
                Console.WriteLine(excecao);
            }
        }
    }
}