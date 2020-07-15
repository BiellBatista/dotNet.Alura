namespace _03_05_XX_State
{
    public interface IEstadoDeUmOrcamento
    {
        void AplicaDescontoExtra(Orcamento orcamento);
        void Aprova(Orcamento orcamento);
        void Reprova(Orcamento orcamento);
        void Finaliza(Orcamento orcamento);
    }
}
