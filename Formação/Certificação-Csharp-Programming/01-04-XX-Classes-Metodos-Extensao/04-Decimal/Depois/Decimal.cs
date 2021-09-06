using System;

namespace _01_04_XX_Classes_Metodos_Extensao.Depois
{
    internal class Decimal : IAulaItem
    {
        public void Executar()
        {
            double valorProduto1 = 10;
            double valorProduto2 = 20;
            double subtotal = 30;

            Console.WriteLine("Descobrindo se 10 + 20 == 30");
            Console.WriteLine((valorProduto1 + valorProduto2) == subtotal);

            valorProduto1 = 10.10;
            valorProduto2 = 20.20;
            subtotal = 30.30;

            Console.WriteLine("Descobrindo se (10.10 + 20.20) == 30.30");
            Console.WriteLine((valorProduto1 + valorProduto2) == subtotal);

            Console.WriteLine(valorProduto1 + valorProduto2);

            Console.WriteLine("Descobrindo se (10.10 + 20.20) == 30.299999999999997");
            Console.WriteLine((valorProduto1 + valorProduto2) == 30.299999999999997);

            decimal materiaPrima = 10.1m;
            decimal maoDeObra = 20.2m;
            decimal custo = 30.3m;

            Console.WriteLine("Descobrindo se (10.1m + 20.2m) == 30.3m");
            Console.WriteLine((materiaPrima + maoDeObra) == custo);
        }
    }
}