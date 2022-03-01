using _04_XX_Testes_Interface_Usando_Selenium.Aplicacao.AplicacaoServico;
using _04_XX_Testes_Interface_Usando_Selenium.Aplicacao.DTO;
using _04_XX_Testes_Interface_Usando_Selenium.Dados.Repositorio;
using _04_XX_Testes_Interface_Usando_Selenium.Dominio.Interfaces.Repositorios;
using _04_XX_Testes_Interface_Usando_Selenium.Dominio.Interfaces.Servicos;
using _04_XX_Testes_Interface_Usando_Selenium.Dominio.Services;
using System.Collections.Generic;

namespace _04_XX_Testes_Interface_Usando_Selenium.Apresentacao.Comandos
{
    internal class ContaCorrenteComando
    {
        private IContaCorrenteRepositorio _repositorio;
        private IContaCorrenteServico _servico;
        private ContaCorrenteServicoApp contaCorrenteServicoApp;

        public ContaCorrenteComando()
        {
            _repositorio = new ContaCorrenteRepositorio();
            _servico = new ContaCorrenteServico(_repositorio);
            contaCorrenteServicoApp = new ContaCorrenteServicoApp(_servico);
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