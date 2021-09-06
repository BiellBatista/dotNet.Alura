using System;

namespace _07_06_XX_Projecao_Dados.Depois
{
    public class DelegadosLambda : IAulaItem
    {
        private delegate int Operacao(int a, int b);

        public void Executar()
        {
            int a = 3;
            int b = 2;

            Operacao operacao = Somar;

            Console.WriteLine(operacao(a, b));

            operacao = Subtrair;

            Console.WriteLine(operacao(a, b));

            Console.ReadKey();
        }

        public int Somar(int a, int b)
        {
            Console.WriteLine($"A operação Somar foi chamada com a = {a} e b = {b}");

            return a + b;
        }

        public int Subtrair(int a, int b)
        {
            Console.WriteLine($"A operação Subtrair foi chamada com a = {a} e b = {b}");

            return a - b;
        }
    }
}