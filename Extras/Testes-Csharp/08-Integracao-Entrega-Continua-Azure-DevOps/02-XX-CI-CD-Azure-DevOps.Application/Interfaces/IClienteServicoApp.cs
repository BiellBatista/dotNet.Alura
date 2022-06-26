using _02_XX_CI_CD_Azure_DevOps.Application.DTO;

namespace _02_XX_CI_CD_Azure_DevOps.Application.Interfaces
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