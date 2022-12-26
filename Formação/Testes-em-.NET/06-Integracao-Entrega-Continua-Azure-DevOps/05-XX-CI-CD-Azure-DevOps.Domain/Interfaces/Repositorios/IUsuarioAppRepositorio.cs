using _05_XX_CI_CD_Azure_DevOps.Domain.Entidades;

namespace _05_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IDisposable
    {
        public List<UsuarioApp> ObterTodos();

        public UsuarioApp ObterPorId(int id);

        public bool Adicionar(UsuarioApp usuario);

        public bool Atualizar(int id, UsuarioApp usuario);

        public bool Excluir(int id);
    }
}