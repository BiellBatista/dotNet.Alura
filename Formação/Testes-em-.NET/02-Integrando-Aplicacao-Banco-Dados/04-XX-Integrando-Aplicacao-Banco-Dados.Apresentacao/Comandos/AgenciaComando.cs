﻿using _04_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.AplicacaoServico;
using _04_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.DTO;
using _04_XX_Integrando_Aplicacao_Banco_Dados.Dados.Repositorio;
using _04_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Interfaces.Repositorios;
using _04_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Interfaces.Servicos;
using _04_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Services;
using System.Collections.Generic;

namespace _04_XX_Integrando_Aplicacao_Banco_Dados.Apresentacao.Comandos
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