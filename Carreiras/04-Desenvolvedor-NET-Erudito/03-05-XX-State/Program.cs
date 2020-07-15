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
