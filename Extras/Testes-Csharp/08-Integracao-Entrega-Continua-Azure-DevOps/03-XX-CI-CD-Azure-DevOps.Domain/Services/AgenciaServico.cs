using _03_XX_CI_CD_Azure_DevOps.Domain.Entidades;
using _03_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Repositorios;
using _03_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Servicos;

namespace _03_XX_CI_CD_Azure_DevOps.Domain.Services
{
    public class AgenciaServico : IAgenciaServico
    {
        private readonly IAgenciaRepositorio _repositorio;

        public AgenciaServico(IAgenciaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public bool Adicionar(Agencia agencia)
        {
            return _repositorio.Adicionar(agencia);
        }

        public bool Atualizar(int id, Agencia agencia)
        {
            return _repositorio.Atualizar(id, agencia);
        }

        public bool Excluir(int id)
        {
            return _repositorio.Excluir(id);
        }

        public Agencia ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public Agencia ObterPorGuid(Guid guid)
        {
            return _repositorio.ObterPorGuid(guid);
        }

        public List<Agencia> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public void Dispose()
        {
            _repositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}