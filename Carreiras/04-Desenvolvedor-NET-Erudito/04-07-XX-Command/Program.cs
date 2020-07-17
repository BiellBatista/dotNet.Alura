using _04_07_XX_Command.Command;
using System;

namespace _04_07_XX_Command
{
    public class Program
    {
        static void Main(string[] args)
        {
            Pedido pedido1 = new Pedido("Gabriel", 100);
            Pedido pedido2 = new Pedido("Letícia", 200);

            FilaDeTrabalho fila = new FilaDeTrabalho();

            fila.Adiciona(new PagaPedido(pedido1));
            fila.Adiciona(new PagaPedido(pedido2));

            fila.Adiciona(new FinalizaPedido(pedido1));

            Console.ReadLine();
        }
    }
}

/**
 * Qual a diferença entre Command e Strategy?
 * Novamente, em termos de implementação, eles são bem parecidos, pois dependem de interfaces.
 * A ideia do Command é abstrair um comando que deve ser executado, pois não é possível executá-lo naquele momento (pois precisamos por em uma fila ou coisa do tipo).
 * A ideia do Command é abstrair um comando que deve ser executado, pois não é possível executá-lo naquele momento (pois precisamos por em uma fila ou coisa do tipo).
 * 
 * Você consegue ver o Command trabalhando junto com algum outro padrão?
 * Podemos ser criativos e usar outros padrões de projeto de acordo com o problema que temos em mãos.
 * Podemos usar Memento para restaurar estados de objetos que foram alterados por um Command.
 * Lembre-se. Aprenda a motivação de cada padrão, e aí use-os sempre que precisar.
 */
