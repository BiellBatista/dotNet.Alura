using _02_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades;
using _02_XX_Testes_Interface_Usando_Selenium.Dominio.Interfaces.Repositorios;
using _02_XX_Testes_Interface_Usando_Selenium.Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_XX_Testes_Interface_Usando_Selenium.Dados.Repositorio
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
                    return null;
                }
                return agencia;
            }
            catch
            {
                throw new Exception($"Erro ao obter agência com Id = {id}.");
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