using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _11_06_XX_Async_Await_Colecoes_Simultaneas_Bloqueios.Depois
{
    public class Startup0601 : IAulaItem
    {
        private long somaGeral;
        private object somaGeralObject = new object();
        private int[] items = Enumerable.Range(0, 100001).ToArray();

        private void AdicionaFaixaDeValores(int inicial, int final)
        {
            while (inicial < final)
            {
                somaGeral = somaGeral + items[inicial];
                inicial++;
            }
        }

        public void Executar()
        {
            long subtotal = 0;
            int tamanhoFaixa = 1000;
            int inicioFaixa = 0;

            int inicial = inicioFaixa;
            int final = inicioFaixa + tamanhoFaixa;

            while (inicial < final)
            {
                subtotal = subtotal + items[inicial];
                inicial++;
            }

            //lock (somaGeralObject)
            //{
            //    somaGeral = somaGeral + subtotal;
            //}

            Monitor.Enter(somaGeralObject);

            try
            {
                somaGeral = somaGeral + subtotal;
            }
            finally
            {
                Monitor.Exit(somaGeralObject);
            }
        }

        private void Main(string[] args)
        {
            while (true)
            {
                Executar();
                Thread.Sleep(1000);
            }
        }

        private void Executar02()
        {
            somaGeral = 0;

            List<Task> tarefas = new List<Task>();
            int tamanhoFaixa = 1000;
            int inicioFaixa = 0;

            while (inicioFaixa < items.Length)
            {
                int fimFaixa = inicioFaixa + tamanhoFaixa;

                if (fimFaixa > items.Length)
                    fimFaixa = items.Length;

                // cria uma cópia local dos parâmetros
                int i = inicioFaixa;
                int f = fimFaixa;

                tarefas.Add(Task.Run(() => AdicionaFaixaDeValores(i, f)));
                inicioFaixa = fimFaixa;
            }

            Task.WaitAll(tarefas.ToArray());

            Console.WriteLine("A soma geral é: {0}", somaGeral);
        }
    }
}