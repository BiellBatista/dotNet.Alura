using _03_XX_Testes_Interface_Usando_Selenium.Aplicacao.AplicacaoServico;
using _03_XX_Testes_Interface_Usando_Selenium.Aplicacao.DTO;
using _03_XX_Testes_Interface_Usando_Selenium.Dados.Repositorio;
using _03_XX_Testes_Interface_Usando_Selenium.Domain.Interfaces.Repositorios;
using _03_XX_Testes_Interface_Usando_Selenium.Domain.Interfaces.Servicos;
using _03_XX_Testes_Interface_Usando_Selenium.Domain.Services;
using System.Collections.Generic;

namespace _03_XX_Testes_Interface_Usando_Selenium.Apresentacao.Comandos
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