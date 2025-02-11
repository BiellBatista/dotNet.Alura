﻿using _04_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Entidades;
using _04_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Interfaces.Repositorios;
using _04_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace _04_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Services
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