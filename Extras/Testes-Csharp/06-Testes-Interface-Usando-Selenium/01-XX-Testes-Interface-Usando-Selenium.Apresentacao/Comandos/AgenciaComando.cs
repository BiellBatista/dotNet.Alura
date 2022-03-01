using _01_XX_Testes_Interface_Usando_Selenium.Aplicacao.AplicacaoServico;
using _01_XX_Testes_Interface_Usando_Selenium.Aplicacao.DTO;
using _01_XX_Testes_Interface_Usando_Selenium.Dados.Repositorio;
using _01_XX_Testes_Interface_Usando_Selenium.Dominio.Interfaces.Repositorios;
using _01_XX_Testes_Interface_Usando_Selenium.Dominio.Interfaces.Servicos;
using _01_XX_Testes_Interface_Usando_Selenium.Dominio.Services;
using System.Collections.Generic;

namespace _01_XX_Testes_Interface_Usando_Selenium.Apresentacao.Comandos
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