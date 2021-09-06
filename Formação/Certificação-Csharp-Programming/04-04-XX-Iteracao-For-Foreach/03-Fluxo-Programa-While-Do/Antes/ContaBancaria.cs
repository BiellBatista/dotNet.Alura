using System;

namespace _04_04_XX_Iteracao_For_Foreach.Antes
{
    internal class ContaBancaria3
    {
        private decimal saldo = 0m;

        public ContaBancaria3(decimal saldo)
        {
            this.saldo = saldo;

            Console.WriteLine(this);
        }

        public void SacarDinheiro(decimal quantia)
        {
            if (saldo < quantia)
            {
                Console.WriteLine("Saldo insuficiente.");

                return;
            }

            Sacar(quantia);
            ImprimirComprovante();

            ///<image url="$(ProjectDir)\img3.png"/>
        }

        private bool TemSaldoSuficiente(decimal quantia)
        {
            return quantia <= saldo;
        }

        private void ImprimirComprovante()
        {
            Console.WriteLine("Comprovante impresso.");
        }

        private void Sacar(decimal quantia)
        {
            Console.WriteLine($"Sacando {quantia:C}");

            saldo = saldo - quantia;

            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Saldo: {saldo:C}";
        }
    }
}