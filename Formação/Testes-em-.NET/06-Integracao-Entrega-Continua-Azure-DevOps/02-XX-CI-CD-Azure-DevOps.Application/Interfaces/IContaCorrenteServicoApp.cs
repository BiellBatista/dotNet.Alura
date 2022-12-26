using _02_XX_CI_CD_Azure_DevOps.Application.DTO;

namespace _02_XX_CI_CD_Azure_DevOps.Application.Interfaces
{
    public interface IContaCorrenteServicoApp : IDisposable
    {
        public List<ContaCorrenteDTO> ObterTodos();

        public ContaCorrenteDTO ObterPorId(int id);

        public ContaCorrenteDTO ObterPorGuid(Guid guid);

        public bool Adicionar(ContaCorrenteDTO cliente);

        public bool Atualizar(int id, ContaCorrenteDTO cliente);

        public bool Excluir(int id);
    }
}