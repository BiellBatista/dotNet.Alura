using _05_XX_Testes_Interface_Usando_Selenium.Domain.Entidades;
using _05_XX_Testes_Interface_Usando_Selenium.Domain.Interfaces.Repositorios;
using _05_XX_Testes_Interface_Usando_Selenium.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace _05_XX_Testes_Interface_Usando_Selenium.Domain.Services
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