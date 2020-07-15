using System;

namespace _03_04_XX_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Imposto iss = new ISS(new ICMS());

            Orcamento orcamento = new Orcamento(500);

            double valor = iss.Calcula(orcamento);

            Console.WriteLine(valor);
            Console.ReadKey();
        }
    }
}

/**
 * Quando usar o Decorator?
 * 
 * Sempre que percebemos que temos comportamentos que podem ser compostos por comportamentos de outras classes envolvidas em uma mesma hierarquia, como foi o caso dos impostos, que podem ser composto por outros impostos. O Decorator introduz a flexibilidade na composição desses comportamentos, bastando escolher no momento da instanciação, quais instancias serão utilizadas para realizar o trabalho.
 */
