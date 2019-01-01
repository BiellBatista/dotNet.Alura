using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_XX_XX_BibliotecasDLLs.Modelos.Funcionarios
{
    class Diretor : FuncionarioAutenticavel
    {
        //recebendo um cpf ao construir o Diretor e passando o argumento para o contrutor da classe base (Funcionario)
        public Diretor(string cpf) : base(5000, cpf)
        {
            Console.WriteLine("Criando DIRETOR");
        }

        // override faz com que o método sobrescreva o método virtual ou abstract da base
        internal protected override double GetBonificacao()
        {
            // a palavra base serve para invocar algum método ou membro base
            return Salario * 0.5;
        }

        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }
    }
}
