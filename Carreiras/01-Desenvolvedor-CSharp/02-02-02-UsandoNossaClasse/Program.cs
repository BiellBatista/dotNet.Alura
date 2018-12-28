using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_02_02_UsandoNossaClasse
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaDoGabriel = new ContaCorrente();

            contaDoGabriel.titular = "Gabriel";
            contaDoGabriel.agencia = 863;

            Console.WriteLine($"Titular: {contaDoGabriel.titular}");
            Console.WriteLine($"Agência: {contaDoGabriel.agencia}");
            Console.WriteLine($"Número: {contaDoGabriel.numero}");
            Console.WriteLine($"Saldo: R${contaDoGabriel.saldo}");
            Console.ReadLine();
        }
    }
}
