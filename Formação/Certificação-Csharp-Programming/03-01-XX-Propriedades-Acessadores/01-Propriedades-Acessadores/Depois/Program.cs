using System;

namespace _03_01_XX_Propriedades_Acessadores.Depois
{
    class Program
    {
        static void Main(string[] args)
        {
            Funcionario funcionario = new Funcionario(1000);
            Console.WriteLine(funcionario.Salario);
        }
    }

    class Funcionario
    {
        //aula 4
        //decimal salario;

        //public decimal Salario //encapsulamento do campo salario
        //{
        //    get
        //    {
        //        return salario;
        //    }

        //    set
        //    {
        //        if (value < 0)
        //        {
        //            throw new ArgumentOutOfRangeException("O salário não pode ser negativo.");
        //        }

        //        salario = value;
        //    }
        //}

        //propriedade autoimplementada
        //public decimal Salario { get; set; }

        decimal salario;

        public decimal Salario //encapsulamento do campo salario
        {
            get
            {
                return salario;
            }
            //sem o set, a propriedade fica somente leitura
            //set
            //{
            //    if (value < 0)
            //    {
            //        throw new ArgumentOutOfRangeException("O salário não pode ser negativo.");
            //    }

            //    salario = value;
            //}
        }

        public Funcionario(decimal salario)
        {
            if (salario < 0)
            {
                throw new ArgumentOutOfRangeException("O salário não pode ser negativo.");
            }

            this.salario = salario;
        }
    }
}
