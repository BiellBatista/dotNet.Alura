using System;

namespace _03_01_XX_Propriedades_Acessadores.Depois
{
    class Program
    {
        static void Main(string[] args)
        {
            Funcionario funcionario = new Funcionario();
            funcionario.Salario = 1000;
            Console.WriteLine(funcionario.Salario);

            funcionario.Salario = -1200;
        }
    }

    class Funcionario
    {
        decimal salario;

        public decimal Salario //encapsulamento do campo salario
        {
            get
            {
                return salario;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("O salário não pode ser negativo.");
                }

                salario = value;
            }
        }
    }
}
