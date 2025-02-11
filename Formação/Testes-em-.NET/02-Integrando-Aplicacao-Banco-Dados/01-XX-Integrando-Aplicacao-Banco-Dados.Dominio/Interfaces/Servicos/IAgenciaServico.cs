﻿using _01_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace _01_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Interfaces.Servicos
{
    public interface IAgenciaServico : IDisposable
    {
        public List<Agencia> ObterTodos();

        public Agencia ObterPorId(int id);

        public Agencia ObterPorGuid(Guid guid);

        public bool Adicionar(Agencia agencia);

        public bool Atualizar(int id, Agencia agencia);

        public bool Excluir(int id);
    }
}