using System;

namespace _01_05_XX_Heranca
{
    public class ContaEstudante : ContaComum
    {
        public int Milhas { get; private set; }

        public override void Depositar(double valor)
        {
            base.Depositar(valor);
            Milhas += (int)valor;
        }

        public override void SomarInvestimentos()
        {
            throw new Exception("Uma conta de estudante não possui investimentos.");
        }
    }
}
