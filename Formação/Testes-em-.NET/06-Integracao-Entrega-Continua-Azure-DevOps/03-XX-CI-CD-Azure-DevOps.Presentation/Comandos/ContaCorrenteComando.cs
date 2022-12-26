using _03_XX_CI_CD_Azure_DevOps.Data.Repositorio;
using _03_XX_CI_CD_Azure_DevOps.Domain.Services;
using _03_XX_CI_CD_Azure_DevOps.Application.AplicacaoServico;
using _03_XX_CI_CD_Azure_DevOps.Application.DTO;
using _03_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Repositorios;
using _03_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Servicos;

namespace _03_XX_CI_CD_Azure_DevOps.Presentation.Comandos
{
    internal class ContaCorrenteComando
    {
        private IContaCorrenteRepositorio _repositorio;
        private IContaCorrenteServico _servico;
        private IClienteServico _cliente;
        private IAgenciaServico _agencia;
        private ContaCorrenteServicoApp contaCorrenteServicoApp;

        public ContaCorrenteComando()
        {
            _repositorio = new ContaCorrenteRepositorio();
            _servico = new ContaCorrenteServico(_repositorio);
            contaCorrenteServicoApp = new ContaCorrenteServicoApp(_servico, _agencia, _cliente);
        }

        public bool Adicionar(ContaCorrenteDTO conta)
        {
            return contaCorrenteServicoApp.Adicionar(conta);
        }

        public bool Atualizar(int id, ContaCorrenteDTO conta)
        {
            return contaCorrenteServicoApp.Atualizar(id, conta);
        }

        public bool Excluir(int id)
        {
            return contaCorrenteServicoApp.Excluir(id);
        }

        public ContaCorrenteDTO ObterPorId(int id)
        {
            return contaCorrenteServicoApp.ObterPorId(id);
        }

        public List<ContaCorrenteDTO> ObterTodos()
        {
            return contaCorrenteServicoApp.ObterTodos();
        }
    }
}