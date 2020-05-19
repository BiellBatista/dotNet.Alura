using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_04_XX_Encapsulamento
{
    public class Boleto
    {
        protected double _valor;

        public double Valor { get { return _valor; } }

        public Boleto(double valor)
        {
            _valor = valor;
        }
    }
}
