using System;

namespace _01_05_XX_Heranca
{
    public class ContaComum
    {
        public double Saldo { get; protected set; }

        public ContaComum()
        {
            Saldo = 0;
        }

        public virtual void Depositar(double valor)
        {
            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public virtual void SomarInvestimentos()
        {
            Saldo += Saldo * 0.01;
        }
    }
}
