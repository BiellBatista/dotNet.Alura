using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_XX_XX_BibliotecasDLLs.Modelos.Funcionarios
{
    public abstract class Funcionario
    {
        public static int TotalDeFuncionarios { get; private set; }
        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }

        public Funcionario(double salario, string cpf)
        {
            Console.WriteLine("Criando FUNCIONARIO");
            CPF = cpf;
            Salario = salario;
            TotalDeFuncionarios++;
        }
        // this() faz eu chamar um outro construtor do mesmo objeto
        public Funcionario(string cpf) : this(1500, cpf) // o this no construtor indica qual construtor será executado antes
        {
        }

        // virtual permite que o método seja sobrescrito
        /*public virtual double GetBonificacao()
        {
            return Salario * 0.10;
        }*/
        public abstract double GetBonificacao();

        // virtual permite que o método seja sobrescrito
        /*public virtual void AumentarSalario()
        {
            Salario *= 1.1;
        }*/
        public abstract void AumentarSalario();
    }
}
