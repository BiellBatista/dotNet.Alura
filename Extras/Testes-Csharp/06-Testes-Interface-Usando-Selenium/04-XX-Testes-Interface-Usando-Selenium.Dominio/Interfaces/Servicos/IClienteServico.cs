﻿using _04_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace _04_XX_Testes_Interface_Usando_Selenium.Dominio.Interfaces.Servicos
{
    public interface IClienteServico : IDisposable
    {
        public List<Cliente> ObterTodos();

        public Cliente ObterPorId(int id);

        public Cliente ObterPorGuid(Guid guid);

        public bool Adicionar(Cliente cliente);

        public bool Atualizar(int id, Cliente cliente);

        public bool Excluir(int id);
    }
}