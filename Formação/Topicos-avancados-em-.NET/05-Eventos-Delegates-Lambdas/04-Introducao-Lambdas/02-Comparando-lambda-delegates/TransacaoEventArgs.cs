namespace _02_Comparando_lambda_delegates
{
    public class TransacaoEventArgs : SaldoEventArgs
    {
        public decimal ValorTransacao { get; }

        public TransacaoEventArgs(decimal saldo, decimal valorTransacao) : base(saldo)
        {
            ValorTransacao = valorTransacao;
        }
    }
}