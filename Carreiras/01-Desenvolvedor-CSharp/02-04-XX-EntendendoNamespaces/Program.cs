using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_04_XX_EntendendoNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente gabriel = new Cliente();

            gabriel.nome = "Gabriel";
            gabriel.profissao = "Desenvolvedor C#";
            gabriel.cpf = "405.324.214.-56";

            ContaCorrente conta = new ContaCorrente();

            conta.titular = gabriel;
            conta.saldo = 500;
            conta.agencia = 563;
            conta.numero = 5634527;

            Console.WriteLine(gabriel.nome);
            Console.WriteLine(conta.titular.nome);
            Console.ReadLine();
        }
    }
}
