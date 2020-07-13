using System;

namespace _03_04_XX_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculadorDeDesconto calculador = new CalculadorDeDesconto();

            Orcamento orcamento = new Orcamento(500);

            orcamento.AdicionaItem(new Item("CANETA", 500));
            orcamento.AdicionaItem(new Item("LAPIS", 500));
            orcamento.AdicionaItem(new Item("GELADEIRA", 500));
            orcamento.AdicionaItem(new Item("FOGAO", 500));
            orcamento.AdicionaItem(new Item("MICROONDAS", 500));
            orcamento.AdicionaItem(new Item("XBOX", 500));

            double desconto = calculador.Calcula(orcamento);

            Console.WriteLine(desconto);

            Console.ReadKey();
        }
    }
}
