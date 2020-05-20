using System;
using System.Collections.Generic;

namespace _01_05_XX_Heranca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IList<ContaComum> contas = ContasDoBanco();

            foreach (ContaComum conta in contas)
            {
                conta.SomarInvestimentos();

                Console.WriteLine("Novo saldo: " + conta.Saldo);
            }

            Console.ReadLine();
        }

        private static IList<ContaComum> ContasDoBanco()
        {
            IList<ContaComum> contas = new List<ContaComum>();
            contas.Add(UmaContaComum(100));
            contas.Add(UmaContaComum(150));
            contas.Add(UmaContaEstudante(100));

            return contas;
        }

        private static ContaComum UmaContaComum(double saldo)
        {
            ContaComum conta = new ContaComum();
            conta.Depositar(saldo);

            return conta;
        }

        private static ContaEstudante UmaContaEstudante(double saldo)
        {
            ContaEstudante conta = new ContaEstudante();
            conta.Depositar(saldo);

            return conta;
        }
    }
}
