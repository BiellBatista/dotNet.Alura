using System;

namespace _03_02_XX_Chain_Responsibility
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

/**
 * Quando usar o Chain of Responsibility?
 * 
 * O padrão Chain of Responsibility cai como uma luva quando temos uma lista de comandos a serem executados de acordo com algum cenário em específico, e sabemos também qual o próximo cenário que deve ser validado, caso o anterior não satisfaça a condição.
 * Nesses casos, o Chain of Responsibility nos possibilita a separação de responsabilidades em classes pequenas e enxutas, e ainda provê uma maneira flexível e desacoplada de juntar esses comportamentos novamente.
 */
