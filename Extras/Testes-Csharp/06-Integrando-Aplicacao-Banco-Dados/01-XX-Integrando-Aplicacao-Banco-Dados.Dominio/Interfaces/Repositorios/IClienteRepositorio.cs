using _01_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace _01_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Interfaces.Repositorios
{
    public interface IClienteRepositorio : IDisposable
    {
        public List<Cliente> ObterTodos();

        public Cliente ObterPorId(int id);

        public Cliente ObterPorGuid(Guid guid);

        public bool Adicionar(Cliente cliente);

        public bool Atualizar(int id, Cliente cliente);

        public bool Excluir(int id);
    }
}