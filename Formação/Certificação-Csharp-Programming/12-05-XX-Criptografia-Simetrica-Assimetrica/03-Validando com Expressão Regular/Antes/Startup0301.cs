using System;

namespace _12_05_XX_Criptografia_Simetrica_Assimetrica.Antes
{
    public class Startup0301 : IAulaItem
    {
        public void Executar()
        {
            ContaCorrente conta = new ContaCorrente("1235-7", "José da Silva", 100.0m);

            Console.WriteLine(conta);
            Console.WriteLine();
            Console.ReadLine();
        }
    }

    internal class ContaCorrente
    {
        public string Numero { get; set; }
        public string Titular { get; set; }
        public decimal Saldo { get; set; }

        public override string ToString()
        {
            return $"Número C/C: {Numero}\nTitular: {Titular}\nSaldo: {Saldo:C}";
        }

        public ContaCorrente(string numero, string titular, decimal saldoInicial)
        {
            Numero = numero;
            Titular = titular;
            Saldo = saldoInicial;
        }
    }
}