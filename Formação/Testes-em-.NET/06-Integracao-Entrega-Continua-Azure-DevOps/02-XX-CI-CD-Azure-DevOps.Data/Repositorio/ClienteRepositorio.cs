﻿using _02_XX_CI_CD_Azure_DevOps.Data.Contexto;
using _02_XX_CI_CD_Azure_DevOps.Domain.Entidades;
using _02_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace _02_XX_CI_CD_Azure_DevOps.Data.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ByteBankContexto _contexto;

        public ClienteRepositorio()
        {
            _contexto = new ByteBankContexto();
        }

        public bool Adicionar(Cliente cliente)
        {
            try
            {
                _contexto.Clientes.Add(cliente);
                _contexto.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Atualizar(int id, Cliente cliente)
        {
            try
            {
                if (id != cliente.Id)
                {
                    return false;
                }
                _contexto.Entry(cliente).State = EntityState.Modified;
                _contexto.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Excluir(int id)
        {
            var cliente = _contexto.Clientes.FirstOrDefault(p => p.Id == id);

            try
            {
                if (cliente == null)
                {
                    return false;
                }
                _contexto.Clientes.Remove(cliente);
                _contexto.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Cliente ObterPorId(int id)
        {
            try
            {
                var cliente = _contexto.Clientes.FirstOrDefault(p => p.Id == id);
                if (cliente == null)
                {
                    return null;
                }
                return cliente;
            }
            catch
            {
                throw new Exception($"Erro ao obter cliente com Id = {id}.");
            }
        }

        public Cliente ObterPorGuid(Guid guid)
        {
            try
            {
                var cliente = _contexto.Clientes.FirstOrDefault(p => p.Identificador == guid);
                if (cliente == null)
                {
                    return null;
                }
                return cliente;
            }
            catch
            {
                throw new Exception($"Erro ao obter cliente com Guid = {guid}.");
            }
        }

        public List<Cliente> ObterTodos()
        {
            try
            {
                return _contexto.Clientes.ToList();
            }
            catch
            {
                throw new Exception("Erro ao obter clientes");
            }
        }

        public void Dispose()
        {
            _contexto.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}