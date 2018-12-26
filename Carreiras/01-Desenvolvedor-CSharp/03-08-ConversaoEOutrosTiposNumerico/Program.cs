using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_08_ConversaoEOutrosTiposNumerico
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando o projeto 4");
            Console.ReadLine();

            double salario = 1200.50;
            int salarioEmInteiro = (int) salario;
            string salarioS = salario.ToString();

            float salarioF = 1200.50f; //o "f" serve para deixar explicito que o valor é um float e não um double

            Console.WriteLine($"Salário em Double {salario}");
            Console.WriteLine($"Salário em Inteiro {salarioEmInteiro}");
            Console.WriteLine($"Salário em String {salarioS}");
            Console.Read();
        }
    }
}
