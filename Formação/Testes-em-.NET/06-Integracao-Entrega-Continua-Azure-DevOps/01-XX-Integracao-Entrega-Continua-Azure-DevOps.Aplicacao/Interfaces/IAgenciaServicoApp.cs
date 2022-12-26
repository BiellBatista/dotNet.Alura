using _01_XX_Integracao_Entrega_Continua_Azure_DevOps.Aplicacao.DTO;

namespace _01_XX_Integracao_Entrega_Continua_Azure_DevOps.Aplicacao.Interfaces
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