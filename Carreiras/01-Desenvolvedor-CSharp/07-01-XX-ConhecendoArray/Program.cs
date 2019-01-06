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
            ListaDeContaCorrente list = new ListaDeContaCorrente();

            list.Adicionar(new ContaCorrente(874, 5679787));
            list.Adicionar(new ContaCorrente(874, 4456668));
            list.Adicionar(new ContaCorrente(874, 7781438));
            //argumento: valor (tipo no python)
            list.ArgumentosNomeados(numero: 6);
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
