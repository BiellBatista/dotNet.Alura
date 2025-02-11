﻿using _03_XX_Testes_Interface_Usando_Selenium.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace _03_XX_Testes_Interface_Usando_Selenium.Domain.Interfaces.Servicos
{
    public interface IContaCorrenteServico : IDisposable
    {
        public List<ContaCorrente> ObterTodos();

        public ContaCorrente ObterPorId(int id);

        public ContaCorrente ObterPorGuid(Guid guid);

        public bool Adicionar(ContaCorrente conta);

        public bool Atualizar(int id, ContaCorrente conta);

        public bool Excluir(int id);
    }
}