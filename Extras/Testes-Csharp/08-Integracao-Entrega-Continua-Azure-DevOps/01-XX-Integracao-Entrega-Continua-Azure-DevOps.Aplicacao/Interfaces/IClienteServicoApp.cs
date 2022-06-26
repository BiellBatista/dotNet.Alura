using _01_XX_Integracao_Entrega_Continua_Azure_DevOps.Aplicacao.DTO;

namespace _01_XX_Integracao_Entrega_Continua_Azure_DevOps.Aplicacao.Interfaces
{
    public interface IClienteServicoApp : IDisposable
    {
        public List<ClienteDTO> ObterTodos();

        public ClienteDTO ObterPorId(int id);

        public ClienteDTO ObterPorGuid(Guid guid);

        public bool Adicionar(ClienteDTO cliente);

        public bool Atualizar(int id, ClienteDTO cliente);

        public bool Excluir(int id);
    }
}