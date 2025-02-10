namespace _03_Lambdas_expressao_instrucao
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