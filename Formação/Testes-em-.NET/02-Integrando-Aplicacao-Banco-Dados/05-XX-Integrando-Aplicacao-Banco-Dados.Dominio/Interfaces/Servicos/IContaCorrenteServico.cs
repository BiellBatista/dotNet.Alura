﻿using _05_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace _05_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Interfaces.Servicos
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