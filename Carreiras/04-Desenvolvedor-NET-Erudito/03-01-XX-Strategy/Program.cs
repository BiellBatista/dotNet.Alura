using System;

namespace _03_01_XX_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Imposto icms = new ICMS();
            Imposto iss = new ISS();

            Orcamento orcamento = new Orcamento(500.0);

            CalculadorDeImpostos calculador = new CalculadorDeImpostos();

            calculador.RealizaCalculo(orcamento, icms);
            calculador.RealizaCalculo(orcamento, iss);

            Console.ReadKey();
        }
    }
}
