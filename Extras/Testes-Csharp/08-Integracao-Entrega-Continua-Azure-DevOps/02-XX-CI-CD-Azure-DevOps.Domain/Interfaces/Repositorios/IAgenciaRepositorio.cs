using _02_XX_CI_CD_Azure_DevOps.Domain.Entidades;

namespace _02_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Repositorios
{
    public interface IAgenciaRepositorio : IDisposable
    {
        public List<Agencia> ObterTodos();

        public Agencia ObterPorId(int id);

        public Agencia ObterPorGuid(Guid guid);

        public bool Adicionar(Agencia agencia);

        public bool Atualizar(int id, Agencia agencia);

        public bool Excluir(int id);
    }
}