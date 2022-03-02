using _01_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace _01_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.Interfaces
{
    public interface IContaCorrenteServicoApp : IDisposable
    {
        public List<ContaCorrenteDTO> ObterTodos();

        public ContaCorrenteDTO ObterPorId(int id);

        public ContaCorrenteDTO ObterPorGuid(Guid guid);

        public bool Adicionar(ContaCorrenteDTO cliente);

        public bool Atualizar(int id, ContaCorrenteDTO cliente);

        public bool Excluir(int id);
    }
}