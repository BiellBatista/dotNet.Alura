﻿using _05_XX_CI_CD_Azure_DevOps.Domain.Entidades;
using _05_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using _05_XX_CI_CD_Azure_DevOps.Data.Contexto;

namespace _05_XX_CI_CD_Azure_DevOps.Data.Repositorio
{
    public class AgenciaRepositorio : IAgenciaRepositorio
    {
        private readonly ByteBankContexto _contexto;

        public AgenciaRepositorio()
        {
            _contexto = new ByteBankContexto();
        }

        public bool Adicionar(Agencia agencia)
        {
            try
            {
                _contexto.Agencias.Add(agencia);
                _contexto.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Atualizar(int id, Agencia agencia)
        {
            try
            {
                if (id != agencia.Id)
                {
                    return false;
                }
                _contexto.Entry(agencia).State = EntityState.Modified;
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
            var agencia = _contexto.Agencias.FirstOrDefault(p => p.Id == id);

            try
            {
                if (agencia == null)
                {
                    return false;
                }
                _contexto.Agencias.Remove(agencia);
                _contexto.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Agencia ObterPorId(int id)
        {
            try
            {
                var agencia = _contexto.Agencias.FirstOrDefault(p => p.Id == id);
                if (agencia == null)
                {
                    throw new Exception($"Erro ao obter agência com Id = {id}.");
                }
                return agencia;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Agencia ObterPorGuid(Guid guid)
        {
            try
            {
                var agencia = _contexto.Agencias.FirstOrDefault(p => p.Identificador == guid);
                if (agencia == null)
                {
                    return null;
                }
                return agencia;
            }
            catch
            {
                throw new Exception($"Erro ao obter agência com Guid = {guid}.");
            }
        }

        public List<Agencia> ObterTodos()
        {
            try
            {
                return _contexto.Agencias.ToList();
            }
            catch
            {
                throw new Exception("Erro ao obter Agências.");
            }
        }

        public void Dispose()
        {
            _contexto.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}