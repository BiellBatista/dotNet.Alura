using _04_XX_Testes_Interface_Usando_Selenium.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace _04_XX_Testes_Interface_Usando_Selenium.Domain.Interfaces.Servicos
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