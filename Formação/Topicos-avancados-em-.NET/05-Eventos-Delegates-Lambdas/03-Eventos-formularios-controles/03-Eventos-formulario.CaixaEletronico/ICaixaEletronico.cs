namespace _03_Eventos_formulario.CaixaEletronico
{
    public interface ICaixaEletronico
    {
        void Depositar(decimal valor);

        void Sacar(decimal valor);

        decimal Saldo();

        string Extrato();

        event SaldoInsuficienteEventHandler OnSaldoInsuficiente;
    }
}