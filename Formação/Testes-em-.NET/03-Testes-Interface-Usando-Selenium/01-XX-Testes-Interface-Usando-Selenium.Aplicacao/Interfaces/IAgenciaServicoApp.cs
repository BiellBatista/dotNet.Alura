﻿using _01_XX_Testes_Interface_Usando_Selenium.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace _01_XX_Testes_Interface_Usando_Selenium.Aplicacao.Interfaces
{
    public interface IAgenciaServicoApp : IDisposable
    {
        public List<AgenciaDTO> ObterTodos();

        public AgenciaDTO ObterPorId(int id);

        public AgenciaDTO ObterPorGuid(Guid guid);

        public bool Adicionar(AgenciaDTO agencia);

        public bool Atualizar(int id, AgenciaDTO agencia);

        public bool Excluir(int id);
    }
}