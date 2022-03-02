using _02_XX_Testes_Interface_Usando_Selenium.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace _02_XX_Testes_Interface_Usando_Selenium.Domain.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IDisposable
    {
        public List<UsuarioApp> ObterTodos();

        public UsuarioApp ObterPorId(int id);

        public bool Adicionar(UsuarioApp usuario);

        public bool Atualizar(int id, UsuarioApp usuario);

        public bool Excluir(int id);
    }
}