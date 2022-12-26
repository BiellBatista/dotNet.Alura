using _02_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.AplicacaoServico;
using _02_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.DTO;
using _02_XX_Integrando_Aplicacao_Banco_Dados.Dados.Repositorio;
using _02_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Interfaces.Repositorios;
using _02_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Interfaces.Servicos;
using _02_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Services;
using System.Collections.Generic;

namespace _02_XX_Integrando_Aplicacao_Banco_Dados.Apresentacao.Comandos
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