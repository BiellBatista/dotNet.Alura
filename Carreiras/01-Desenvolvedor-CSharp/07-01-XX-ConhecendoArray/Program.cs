using _05_XX_XX_BibliotecasDLLs.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_01_XX_ConhecendoArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista<int> idades = new Lista<int>();

            //ListaDeObject listaDeIdades = new ListaDeObject();

            //listaDeIdades.Adicionar(10);
            //listaDeIdades.Adicionar(5);
            //listaDeIdades.Adicionar(4);
            //listaDeIdades.AdicionarVarios(16, 23, 60);

            //for(int i = 0; i < listaDeIdades.Tamanho; i++)
            //{
            //    int idade = (int) listaDeIdades[i];
            //    Console.WriteLine($"Idade no índice {i}: {idade}");
            //}

            //ListaDeContaCorrente lista = new ListaDeContaCorrente();
            //ContaCorrente contaDoGui = new ContaCorrente(11111, 1111111);
            //lista.Adicionar(contaDoGui);
            //lista.Adicionar(new ContaCorrente(874, 5679787));
            //lista.Adicionar(new ContaCorrente(874, 4456668));
            //lista.Adicionar(new ContaCorrente(874, 7781438));
            //lista.Adicionar(new ContaCorrente(874, 5679787));
            //lista.Adicionar(new ContaCorrente(874, 5679754));
            //lista.Adicionar(new ContaCorrente(874, 5679445));
            //lista.Adicionar(new ContaCorrente(874, 5679445));
            //lista.Adicionar(new ContaCorrente(874, 5679445));
            //lista.Adicionar(new ContaCorrente(874, 5679445));
            //lista.Adicionar(new ContaCorrente(874, 5679445));
            //lista.Adicionar(new ContaCorrente(874, 5679445));
            ////argumento: valor (tipo no python)
            ////lista.ArgumentosNomeados(numero: 6);

            //lista.EscreverListaNaTela();
            //lista.Remover(contaDoGui);

            //Console.WriteLine("Após remover o item");

            //lista.EscreverListaNaTela();

            Console.ReadLine();
        }

        static void TestaArraydeContaCorrente()
        {
            //ContaCorrente[] contas = new ContaCorrente[3];
            //contas[0] = new ContaCorrente(874, 5679787);
            //contas[1] = new ContaCorrente(874, 4456668);
            //contas[2] = new ContaCorrente(874, 7781438);

            ContaCorrente[] contas = new ContaCorrente[]
                {
                    new ContaCorrente(874, 5679787),
                    new ContaCorrente(874, 4456668),
                    new ContaCorrente(874, 7781438)
                };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
            }
        }

        static void TestaArrayInt()
        {
            // ARRAY de inteiros, com 5 posições!
            int[] idades = null;
            idades = new int[3];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;

            Console.WriteLine(idades.Length);

            int acumulador = 0;

            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acesso o array idades no índice {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");

                acumulador += idade;
            }

            int media = acumulador / idades.Length;
            Console.WriteLine($"Média de idades = {media}");
        }
    }
}
