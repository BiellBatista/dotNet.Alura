﻿using _01_XX_xUnit_Moq.Core.Models;
using _01_XX_xUnit_Moq.Core.Commands;
using _01_XX_xUnit_Moq.Infrastructure;
using Microsoft.Extensions.Logging;

namespace _01_XX_xUnit_Moq.Services.Handlers
{
    public class CadastraTarefaHandler
    {
        IRepositorioTarefas _repo;
        ILogger<CadastraTarefaHandler> _logger;

        public CadastraTarefaHandler(IRepositorioTarefas repositorio)
        {
            _repo = repositorio;
            _logger = new LoggerFactory().CreateLogger<CadastraTarefaHandler>();
        }

        public void Execute(CadastraTarefa comando)
        {
            var tarefa = new Tarefa
            (
                id: 0,
                titulo: comando.Titulo,
                prazo: comando.Prazo,
                categoria: comando.Categoria,
                concluidaEm: null,
                status: StatusTarefa.Criada
            );
            _logger.LogDebug("Persistindo a tarefa...");
            _repo.IncluirTarefas(tarefa);
        }
    }
}
