using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace _11_06_XX_Async_Await_Colecoes_Simultaneas_Bloqueios.Depois
{
    //Gerenciar dados usando coleções simultâneas
    public class Startup0501 : IAulaItem
    {
        public void Executar()
        {
            int NUMERO_ITENS = 30;
            ConcurrentDictionary<int, int> dicionario = new ConcurrentDictionary<int, int>();

            Console.WriteLine("Inicializando dicionário...");

            for (int i = 0; i < NUMERO_ITENS; i++)
            {
                dicionario[i] = 0;
            }

            ImprimirItens(dicionario);

            Console.WriteLine("Incrementando valores...");

            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < NUMERO_ITENS; i++)
                {
                    int valor;

                    do
                    {
                        valor = dicionario[i];
                    } while (!dicionario.TryUpdate(i, valor + 1, valor));

                    Thread.Sleep(i);
                }
            });

            thread1.Start();

            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < NUMERO_ITENS; i++)
                {
                    int valor;

                    do
                    {
                        valor = dicionario[i];
                    } while (!dicionario.TryUpdate(i, valor + 1, valor));

                    Thread.Sleep(i);
                }
            });

            thread2.Start();
            thread1.Join();
            thread2.Join();

            ImprimirItens(dicionario);

            Console.WriteLine("Tecle [ENTER] para continuar");
            Console.ReadLine();
        }

        private void ImprimirItens(IDictionary<int, int> cd)
        {
            for (int i = 0; i < cd.Count; i++)
            {
                Console.WriteLine("dicionario[{0}] = {1}", i, cd[i]);
            }
        }
    }
}