using _01_XX_xUnit_Moq.Core.Models;
using _01_XX_xUnit_Moq.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_XX_xUnit_Moq.ConsoleApp
{
    public class RepoFakeTarefas : IRepositorioTarefas
    {
        List<Tarefa> lista = new List<Tarefa>();

        public void AtualizarTarefas(params Tarefa[] tarefas)
        {
            throw new NotImplementedException();
        }

        public void ExcluirTarefas(params Tarefa[] tarefas)
        {
            throw new NotImplementedException();
        }

        public void IncluirTarefas(params Tarefa[] tarefas)
        {
            tarefas.ToList().ForEach(t => lista.Add(t));
        }

        public Categoria ObtemCategoriaPorId(int id)
        {
            return new Categoria(id, string.Empty);
        }

        public IEnumerable<Tarefa> ObtemTarefas(Func<Tarefa, bool> filtro)
        {
            return lista;
        }
    }
}
