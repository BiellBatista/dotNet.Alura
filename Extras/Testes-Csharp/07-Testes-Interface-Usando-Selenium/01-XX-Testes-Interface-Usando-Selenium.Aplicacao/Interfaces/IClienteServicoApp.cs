using _01_XX_Testes_Interface_Usando_Selenium.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace _01_XX_Testes_Interface_Usando_Selenium.Aplicacao.Interfaces
{
    public interface IClienteServicoApp : IDisposable
    {
        public List<ClienteDTO> ObterTodos();

        public ClienteDTO ObterPorId(int id);

        public ClienteDTO ObterPorGuid(Guid guid);

        public bool Adicionar(ClienteDTO cliente);

        public bool Atualizar(int id, ClienteDTO cliente);

        public bool Excluir(int id);
    }
}