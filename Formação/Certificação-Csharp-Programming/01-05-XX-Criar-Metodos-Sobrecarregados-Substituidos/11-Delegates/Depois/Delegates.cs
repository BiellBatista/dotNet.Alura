using System;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Depois
{
    internal class Delegates : IAulaItem
    {
        public void Executar()
        {
            Calculadora.Executar();
        }
    }

    internal delegate double MetodoMultiplicacao(double input);

    internal class Calculadora
    {
        private static double Duplicar(double input)
        {
            return input * 2;
        }

        private static double Triplicar(double input)
        {
            return input * 3;
        }

        public static void Executar()
        {
            //Executa diretamente o método
            Console.WriteLine($"Duplicar(7.5): {Duplicar(7.5)}");

            //Executa diretamente o método
            Console.WriteLine($"Triplicar(7.5): {Triplicar(7.5)}");

            //associando o delegate ao método duplicar, pois eles possuem a mesma assinatura (retorno e parametros)
            MetodoMultiplicacao metodoMultiplicacao = Duplicar;
            Console.WriteLine(metodoMultiplicacao(7.5));

            metodoMultiplicacao = Triplicar;
            Console.WriteLine($"Triplicar(7.5): {metodoMultiplicacao(7.5)}");

            //delegate como metodo anonimo
            MetodoMultiplicacao metodoQuadrado = delegate (double input)
            {
                return input * input;
            };

            double quadrado = metodoQuadrado(5);
            Console.WriteLine("quadrado: {0}", quadrado);

            //delegate com expressao lambda
            MetodoMultiplicacao metodoCubo = input => input * input * input;
            double cubo = metodoCubo(4.375);

            Console.WriteLine("cubo: {0}", cubo);
        }
    }
}