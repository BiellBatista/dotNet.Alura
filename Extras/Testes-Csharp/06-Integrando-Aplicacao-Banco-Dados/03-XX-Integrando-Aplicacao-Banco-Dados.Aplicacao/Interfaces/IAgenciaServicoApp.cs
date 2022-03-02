using _03_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace _03_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.Interfaces
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