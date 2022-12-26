using _01_XX_Integracao_Entrega_Continua_Azure_DevOps.Aplicacao.DTO;

namespace _01_XX_Integracao_Entrega_Continua_Azure_DevOps.Aplicacao.Interfaces
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