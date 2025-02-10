namespace _04_LINQ_sintaxe_metodo.CaixaEletronico
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