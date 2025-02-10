namespace _02_Comparando_lambda_delegates
{
    public interface ICaixaEletronico
    {
        decimal Saldo { get; }

        void Depositar(decimal valor);

        void Sacar(decimal valor);

        string Extrato();

        event SaldoInsuficienteEventHandler OnSaldoInsuficiente;

        event LimiteUtilizadoEventHandler OnLimiteUtilizado;
    }
}