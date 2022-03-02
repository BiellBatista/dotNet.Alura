using _05_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.AplicacaoServico;
using _05_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.DTO;
using _05_XX_Integrando_Aplicacao_Banco_Dados.Dados.Repositorio;
using _05_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Interfaces.Repositorios;
using _05_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Interfaces.Servicos;
using _05_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Services;
using System.Collections.Generic;

namespace _05_XX_Integrando_Aplicacao_Banco_Dados.Apresentacao.Comandos
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