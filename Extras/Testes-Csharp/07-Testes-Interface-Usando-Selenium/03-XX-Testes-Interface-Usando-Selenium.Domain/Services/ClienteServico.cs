using _03_XX_Testes_Interface_Usando_Selenium.Domain.Entidades;
using _03_XX_Testes_Interface_Usando_Selenium.Domain.Interfaces.Repositorios;
using _03_XX_Testes_Interface_Usando_Selenium.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace _03_XX_Testes_Interface_Usando_Selenium.Domain.Services
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteServico(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public bool Adicionar(Cliente cliente)
        {
            return _repositorio.Adicionar(cliente);
        }

        public bool Atualizar(int id, Cliente cliente)
        {
            return _repositorio.Atualizar(id, cliente);
        }

        public bool Excluir(int id)
        {
            return _repositorio.Excluir(id);
        }

        public Cliente ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public Cliente ObterPorGuid(Guid guid)
        {
            return _repositorio.ObterPorGuid(guid);
        }

        public List<Cliente> ObterTodos()
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