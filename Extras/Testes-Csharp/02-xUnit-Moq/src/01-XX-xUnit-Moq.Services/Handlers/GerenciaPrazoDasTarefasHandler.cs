using System;
using System.Linq;
using _01_XX_xUnit_Moq.Core.Commands;
using _01_XX_xUnit_Moq.Core.Models;
using _01_XX_xUnit_Moq.Infrastructure;

namespace _01_XX_xUnit_Moq.Services.Handlers
{
    public class GerenciaPrazoDasTarefasHandler
    {
        IRepositorioTarefas _repo;

        public GerenciaPrazoDasTarefasHandler()
        {
            _repo = new RepositorioTarefa();
        }

        public void Execute(GerenciaPrazoDasTarefas comando)
        {
            var agora = comando.DataHoraAtual;

            //pegar todas as tarefas não concluídas que passaram do prazo
            var tarefas = _repo
                .ObtemTarefas(t => t.Prazo <= agora && t.Status != StatusTarefa.Concluida)
                .ToList();

            //atualizá-las com status Atrasada
            tarefas.ForEach(t => t.Status = StatusTarefa.EmAtraso);

            //salvar tarefas
            _repo.AtualizarTarefas(tarefas.ToArray());
        }
    }
}
