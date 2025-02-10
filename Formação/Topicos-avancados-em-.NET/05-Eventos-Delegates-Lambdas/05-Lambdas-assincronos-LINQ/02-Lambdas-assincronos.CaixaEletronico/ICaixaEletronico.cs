namespace _02_Lambdas_assincronos.CaixaEletronico
{
    public interface ICaixaEletronico
    {
        decimal Saldo { get; }

        void Depositar(decimal valor);

        void Sacar(decimal valor);

        string Extrato();

        event SaldoInsuficienteEventHandler OnSaldoInsuficiente;
    }
}