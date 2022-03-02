using _01_XX_Testes_Interface_Usando_Selenium.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace _01_XX_Testes_Interface_Usando_Selenium.Aplicacao.Interfaces
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