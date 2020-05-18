using _01_02_XX_Acoplamento;
using System;

namespace _01_03_XX_OCP_DIP
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
