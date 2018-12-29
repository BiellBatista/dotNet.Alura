using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_01_XX_ConhecendoOProblemaDoCliente.Funcionarios
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public double Salario { get; set; }
        // virtual permite que o método seja sobrescrito
        public virtual double GetBonificacao()
        {
            return Salario * 0.10;
        }
    }
}
