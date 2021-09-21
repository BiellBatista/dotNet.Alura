using System;
using System.Threading;
using System.Threading.Tasks;

namespace _11_07_XX_Cancelamento_Tarefas_Metodos_Thread_Safe.Antes
{
    //Lançando uma exceção quando a tarefa é cancelada
    public class Startup0702 : IAulaItem
    {
        public void Executar()
        {
            Console.WriteLine("Tecle algo para parar o relógio");

            Task contagem = new Task(() => ContagemRegressiva());

            contagem.Start();

            Console.ReadKey();
            Console.WriteLine("A contagem foi completada.");
            Console.ReadLine();
        }

        private void ContagemRegressiva()
        {
            int contador = 7;

            while (contador > 0)
            {
                Console.WriteLine("contador: {0}", contador);

                Thread.Sleep(500);

                contador--;
            }
        }
    }
}