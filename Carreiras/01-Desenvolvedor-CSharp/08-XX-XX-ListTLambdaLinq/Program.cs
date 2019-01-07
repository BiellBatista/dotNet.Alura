using _05_XX_XX_BibliotecasDLLs.Modelos;
using _08_XX_XX_ListTLambdaLinq.Comparadores;
using _08_XX_XX_ListTLambdaLinq.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_XX_XX_ListTLambdaLinq
{
    public class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 6),
                null,
                new ContaCorrente(342, 5),
                new ContaCorrente(340, 4),
                null,
                null,
                new ContaCorrente(290, 3),
                new ContaCorrente(290, 2),
                new ContaCorrente(290, 1)
            };
            /**
             * ordene a lista de contas pelo número.
             * devo colocar no argumento o objeto, o operador lambda (=>) serve para varear o objeto que tem o IComparaber
             * */
            //IOrderedEnumerable<ContaCorrente> contasOrdenadas = contas.OrderBy(conta => conta.Numero);
            //o OrderBy() não detectar null

            //posso escrever código no parâmetro do lambda
            // int.MaxValue; retorna o maior valor de um inteiro de 32 bits

            var contasNaoNulas = contas.Where(conta => conta != null);

            IOrderedEnumerable<ContaCorrente> contasOrdenadas = contasNaoNulas.OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }

            Console.ReadLine();
        }

        static void TesteOrderBy()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 6),
                null,
                new ContaCorrente(342, 5),
                new ContaCorrente(340, 4),
                null,
                null,
                new ContaCorrente(290, 3),
                new ContaCorrente(290, 2),
                new ContaCorrente(290, 1)
            };
            /**
             * ordene a lista de contas pelo número.
             * devo colocar no argumento o objeto, o operador lambda (=>) serve para varear o objeto que tem o IComparaber
             * */
            //IOrderedEnumerable<ContaCorrente> contasOrdenadas = contas.OrderBy(conta => conta.Numero);
            //o OrderBy() não detectar null

            //posso escrever código no parâmetro do lambda
            // int.MaxValue; retorna o maior valor de um inteiro de 32 bits

            IOrderedEnumerable<ContaCorrente> contasOrdenadas =
                contas.OrderBy(conta =>
                {
                    if (conta == null)
                        return int.MaxValue;

                    return conta.Numero;
                });

            foreach (var conta in contasOrdenadas)
            {
                if (conta == null)
                    Console.WriteLine("Conta nula");
                else
                    Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");

            }

            Console.ReadLine();
        }

        static void TestaSorteComIComparer()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 87480),
                new ContaCorrente(342, 45678),
                new ContaCorrente(340, 48950),
                new ContaCorrente(290, 18950)
            };

            contas.Sort(new ComparadorContaCorrentePorAgencia());

            foreach (var conta in contas)
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");

            Console.ReadLine();
        }

        static void TestaSorte()
        {
            //var conta = new ContaCorrente(344, 56456456);
            //var gerenciador = new GerenciadorBonificacao();
            //var gerenciadores = new List<GerenciadorBonificacao>();

            var nomes = new List<string>()
            {
                "Guilherme",
                "Luana",
                "Wellington",
                "Ana"
            };

            nomes.Sort();

            foreach (var nome in nomes)
                Console.WriteLine(nome);


            List<int> idades = new List<int>();

            idades.Add(1);
            idades.Add(5);
            idades.Add(14);
            idades.Add(25);
            idades.Add(38);
            idades.Add(61);

            //Aqui estou usando o método de extensão, posso usar ele invocando a classe que ele foi definido
            //ListExtensoes.AdicionarVarios(idades, 1, 5687, 1987, 1567, 987);
            //ou posso usar ele colocando o objeto (o primeiro parametro com this)
            //o ícone de um método de extensão é o cubo com uma seta pra baixo
            idades.AdicionarVarios(1, 5687, 1987, 1567, 987);
            //idades.Remove(5);
            idades.AdicionarVarios(99, -1);

            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
                Console.WriteLine(idades[i]);
        }
    }
}
