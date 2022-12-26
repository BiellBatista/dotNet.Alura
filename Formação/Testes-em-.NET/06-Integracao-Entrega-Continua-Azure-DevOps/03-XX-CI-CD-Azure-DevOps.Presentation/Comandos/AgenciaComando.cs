using _03_XX_CI_CD_Azure_DevOps.Data.Repositorio;
using _03_XX_CI_CD_Azure_DevOps.Domain.Services;
using _03_XX_CI_CD_Azure_DevOps.Application.AplicacaoServico;
using _03_XX_CI_CD_Azure_DevOps.Application.DTO;
using _03_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Repositorios;
using _03_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Servicos;

namespace _03_XX_CI_CD_Azure_DevOps.Presentation.Comandos
{
    internal class AgenciaComando
    {
        private IAgenciaRepositorio _repositorio;
        private IAgenciaServico _servico;
        private AgenciaServicoApp agenciaServicoApp;

        public AgenciaComando()
        {
            _repositorio = new AgenciaRepositorio();
            _servico = new AgenciaServico(_repositorio);
            agenciaServicoApp = new AgenciaServicoApp(_servico);
        }

        public bool Adicionar(AgenciaDTO agencia)
        {
            return agenciaServicoApp.Adicionar(agencia);
        }

        public bool Atualizar(int id, AgenciaDTO agencia)
        {
            return agenciaServicoApp.Atualizar(id, agencia);
        }

        public bool Excluir(int id)
        {
            return agenciaServicoApp.Excluir(id);
        }

        public AgenciaDTO ObterPorId(int id)
        {
            return agenciaServicoApp.ObterPorId(id);
        }

        public List<AgenciaDTO> ObterTodos()
        {
            return agenciaServicoApp.ObterTodos();
        }
    }
}