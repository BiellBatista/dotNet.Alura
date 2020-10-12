using System;

namespace _07_02_XX_Manipuladores_Eventos.Depois
{
    public class DelegadosLambda : IAulaItem
    {
        delegate int Operacao(int a, int b);

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
