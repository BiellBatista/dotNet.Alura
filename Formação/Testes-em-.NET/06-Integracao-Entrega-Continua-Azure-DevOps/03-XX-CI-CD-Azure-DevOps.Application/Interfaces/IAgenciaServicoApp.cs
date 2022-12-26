using _03_XX_CI_CD_Azure_DevOps.Application.DTO;

namespace _03_XX_CI_CD_Azure_DevOps.Application.Interfaces
{
    public interface IAgenciaServicoApp : IDisposable
    {
        public List<AgenciaDTO> ObterTodos();

        public AgenciaDTO ObterPorId(int id);

        public AgenciaDTO ObterPorGuid(Guid guid);

        public bool Adicionar(AgenciaDTO agencia);

        public bool Atualizar(int id, AgenciaDTO agencia);

        public bool Excluir(int id);
    }
}