using System;

namespace _03_03_XX_Template_Method
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
 * Quando usar o Template Method?
 * 
 * Quando temos diferentes algoritmos que possuem estruturas parecidas, o Template Method é uma boa solução. Com ele, conseguimos definir, em um nível mais macro, a estrutura do algoritmo e deixar "buracos", que serão implementados de maneira diferente por cada uma das implementações específicas.
 * 
 * Dessa forma, reutilizamos ao invés de repetirmos código, e facilitamos possíveis evoluções, tanto do algoritmo em sua estrutura macro, quanto dos detalhes do algoritmo, já que cada classe tem sua responsabilidade bem separada.
 */
