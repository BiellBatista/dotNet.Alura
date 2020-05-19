using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_04_XX_Encapsulamento
{
    public class Pagamento
    {
        private double _valor;

        public Pagamento(double valor)
        {
            _valor = valor;
        }

        public double Valor
        {
            get { return _valor; }
        }
    }
}
