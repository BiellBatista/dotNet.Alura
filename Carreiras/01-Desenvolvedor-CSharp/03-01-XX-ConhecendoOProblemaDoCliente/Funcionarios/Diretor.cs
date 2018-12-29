using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_01_XX_ConhecendoOProblemaDoCliente.Funcionarios
{
    class Diretor : Funcionario
    {
        // override faz com que o método sobrescreva o método virtual da base
        public override double GetBonificacao()
        {
            // a palavra base serve para invocar algum método ou membro base
            return Salario + base.GetBonificacao();
        }
    }
}
