using System;

namespace _03_03_XX_Interfaces_Explicitas.Depois
{
    internal class PropriedadesAcessadores : IAulaItem
    {
        public void Executar()
        {
            Funcionario funcionario = new Funcionario(1000);
            Console.WriteLine(funcionario.Salario);
        }
    }

    internal class Funcionario
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

        private decimal salario;

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