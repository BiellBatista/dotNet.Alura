using System;
using System.Threading;

namespace _11_07_XX_Cancelamento_Tarefas_Metodos_Thread_Safe.Depois
{
    //Implementar métodos thread-safe
    public class Startup0703 : IAulaItem
    {
        public void Executar()
        {
            var contador = new Contador();

            Console.WriteLine("contador: {0}", contador.Numero);

            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    contador.Incrementar();

                    Thread.Sleep(i);
                }
            });

            thread1.Start();
            //thread1.Join();

            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    contador.Incrementar();

                    Thread.Sleep(i);
                }
            });

            thread2.Start();
            thread1.Join();
            thread2.Join();

            Console.WriteLine("contador: {0}", contador.Numero);
            Console.ReadLine();
        }
    }

    internal class Contador
    {
        private object ContadorObject = new object();
        public int Numero { get; private set; } = 0;

        public void Incrementar()
        {
            lock (ContadorObject)
            {
                Numero++;
            }
        }
    }
}