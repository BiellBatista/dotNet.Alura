using System;

namespace _03_05_XX_State
{
    class Program
    {
        static void Main(string[] args)
        {
            Orcamento reforma = new Orcamento(500);

            Console.WriteLine(reforma.Valor);
            reforma.AplicaDescontonExtra();
            Console.WriteLine(reforma.Valor);

            reforma.Aprova();
            reforma.AplicaDescontonExtra();
            Console.WriteLine(reforma.Valor);

            reforma.Finaliza();

            Console.ReadKey();
        }
    }
}

/**
 * Quando usar o State?
 * 
 * A principal situação que faz emergir o Design Pattern State é a necessidade de implementação de uma máquina de estados. Geralmente, o controle das possíveis transições são vários e complexos, fazendo com que a implementação não seja simples. O State auxilia a manter o controle dos estados simples e organizados através da criação de classes que representem cada estado e saiba controlar as transições.
 */
