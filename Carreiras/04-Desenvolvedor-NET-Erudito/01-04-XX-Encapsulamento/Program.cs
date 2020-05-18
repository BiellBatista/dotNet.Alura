using System;

namespace _01_04_XX_Encapsulamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Compra compra = new Compra(500, "sao paulo");
            CalculadoraDePrecos cacl = new CalculadoraDePrecos(new TabelaDePrecoPadrao(), new Frete());

            double resultado = cacl.Calcular(compra);

            Console.WriteLine("O preco da compra e: " + resultado);
            Console.ReadLine();
        }
    }
}
