using _02_XX_CI_CD_Azure_DevOps.Domain.Entidades;

namespace _02_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Repositorios
{
    public interface IContaCorrenteRepositorio : IDisposable
    {
        public List<ContaCorrente> ObterTodos();

        public ContaCorrente ObterPorId(int id);

        public ContaCorrente ObterPorGuid(Guid guid);

        public bool Adicionar(ContaCorrente conta);

        public bool Atualizar(int id, ContaCorrente conta);

        public bool Excluir(int id);
    }
}