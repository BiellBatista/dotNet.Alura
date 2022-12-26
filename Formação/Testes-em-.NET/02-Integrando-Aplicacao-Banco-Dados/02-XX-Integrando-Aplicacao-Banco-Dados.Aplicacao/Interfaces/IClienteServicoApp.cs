using _02_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace _02_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.Interfaces
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