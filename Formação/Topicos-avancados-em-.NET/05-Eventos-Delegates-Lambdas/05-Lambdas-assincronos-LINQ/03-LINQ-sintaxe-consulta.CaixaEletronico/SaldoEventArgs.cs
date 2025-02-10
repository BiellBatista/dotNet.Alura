namespace _03_LINQ_sintaxe_consulta.CaixaEletronico
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