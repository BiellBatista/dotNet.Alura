namespace _02_Comparando_lambda_delegates
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