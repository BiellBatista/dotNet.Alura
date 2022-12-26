using _04_XX_CI_CD_Azure_DevOps.Domain.Entidades;

namespace _04_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Repositorios
{
    public interface IClienteRepositorio : IDisposable
    {
        public List<Cliente> ObterTodos();

        public Cliente ObterPorId(int id);

        public Cliente ObterPorGuid(Guid guid);

        public bool Adicionar(Cliente cliente);

        public bool Atualizar(int id, Cliente cliente);

        public bool Excluir(int id);
    }
}