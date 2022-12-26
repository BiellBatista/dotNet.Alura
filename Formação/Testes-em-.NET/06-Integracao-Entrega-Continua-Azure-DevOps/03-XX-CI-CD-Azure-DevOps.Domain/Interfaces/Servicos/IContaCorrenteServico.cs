using _03_XX_CI_CD_Azure_DevOps.Domain.Entidades;

namespace _03_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Servicos
{
    public interface IContaCorrenteServico : IDisposable
    {
        public List<ContaCorrente> ObterTodos();

        public ContaCorrente ObterPorId(int id);

        public ContaCorrente ObterPorGuid(Guid guid);

        public bool Adicionar(ContaCorrente conta);

        public bool Atualizar(int id, ContaCorrente conta);

        public bool Excluir(int id);
    }
}