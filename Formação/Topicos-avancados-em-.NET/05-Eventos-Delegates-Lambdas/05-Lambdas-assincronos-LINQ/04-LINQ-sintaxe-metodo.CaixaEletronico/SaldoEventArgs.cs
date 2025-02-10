namespace _04_LINQ_sintaxe_metodo.CaixaEletronico
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