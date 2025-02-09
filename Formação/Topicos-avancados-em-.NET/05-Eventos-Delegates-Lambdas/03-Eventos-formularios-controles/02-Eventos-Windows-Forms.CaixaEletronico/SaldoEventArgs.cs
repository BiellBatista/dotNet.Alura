namespace _02_Eventos_Windows_Forms.CaixaEletronico
{
    public class SaldoEventArgs : EventArgs
    {
        public decimal Saldo { get; }

        public SaldoEventArgs(decimal saldo)
        {
            Saldo = saldo;
        }
    }
}