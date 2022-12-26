using _02_XX_CI_CD_Azure_DevOps.Domain.Entidades;

namespace _02_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Servicos
{
    public interface IClienteServico : IDisposable
    {
        public List<Cliente> ObterTodos();

        public Cliente ObterPorId(int id);

        public Cliente ObterPorGuid(Guid guid);

        public bool Adicionar(Cliente cliente);

        public bool Atualizar(int id, Cliente cliente);

        public bool Excluir(int id);
    }
}