﻿using _03_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades;
using _03_XX_Testes_Interface_Usando_Selenium.Dominio.Interfaces.Repositorios;
using _03_XX_Testes_Interface_Usando_Selenium.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace _03_XX_Testes_Interface_Usando_Selenium.Dominio.Services
{
    public class ContaCorrenteServico : IContaCorrenteServico
    {
        private readonly IContaCorrenteRepositorio _repositorio;

        public ContaCorrenteServico(IContaCorrenteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public bool Adicionar(ContaCorrente conta)
        {
            return _repositorio.Adicionar(conta);
        }

        public bool Atualizar(int id, ContaCorrente conta)
        {
            return _repositorio.Atualizar(id, conta);
        }

        public bool Excluir(int id)
        {
            return _repositorio.Excluir(id);
        }

        public ContaCorrente ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public ContaCorrente ObterPorGuid(Guid guid)
        {
            return _repositorio.ObterPorGuid(guid);
        }

        public List<ContaCorrente> ObterTodos()
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