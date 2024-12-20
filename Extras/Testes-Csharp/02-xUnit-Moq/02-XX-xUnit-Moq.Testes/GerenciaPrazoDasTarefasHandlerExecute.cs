﻿using _02_XX_xUnit_Moq.Core.Commands;
using _02_XX_xUnit_Moq.Core.Models;
using _02_XX_xUnit_Moq.Infrastructure;
using _02_XX_xUnit_Moq.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace _02_XX_xUnit_Moq.Testes
{
    public class GerenciaPrazoDasTarefasHandlerExecute
    {
        [Fact]
        public void QuandoTarefasEstiveremAtrasadasDeveMudarSeuStatus()
        {
            //arrange
            var compCateg = new Categoria(1, "Compras");
            var casaCateg = new Categoria(2, "Casa");
            var trabCateg = new Categoria(3, "Trabalho");
            var saudCateg = new Categoria(4, "Saúde");
            var higiCateg = new Categoria(5, "Higiene");

            var tarefas = new List<Tarefa>
            {
                new Tarefa(1, "Tirar lixo", casaCateg, new DateTime(2018, 12, 31), null, StatusTarefa.Criada),
                new Tarefa(4, "Fazer o almoço", casaCateg, new DateTime(2017, 12, 1), null, StatusTarefa.Criada),
                new Tarefa(9, "Ir à academia", saudCateg, new DateTime(2018, 12, 31), null, StatusTarefa.Criada),
                new Tarefa(7, "Concluir o relatório", trabCateg, new DateTime(2018, 5, 7), null, StatusTarefa.Pendente),
                new Tarefa(10, "Beber água", saudCateg, new DateTime(2018, 12, 31), null, StatusTarefa.Criada),
                new Tarefa(8, "Comparecer à reunião", trabCateg, new DateTime(2018, 11, 30), null, StatusTarefa.Concluida),
                new Tarefa(2, "Arrumar a cama", casaCateg, new DateTime(2019, 4, 5), null, StatusTarefa.Criada),
                new Tarefa(3, "Escovar os dentes", higiCateg, new DateTime(2019, 1, 2), null, StatusTarefa.Criada),
                new Tarefa(5, "Compra presente pro João", compCateg, new DateTime(2019, 10, 8), null, StatusTarefa.Criada),
                new Tarefa(6, "Compra rração", compCateg, new DateTime(2019, 11, 20), null, StatusTarefa.Criada),
            };

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(context);

            repo.IncluirTarefas(tarefas.ToArray());

            var comando = new GerenciaPrazoDasTarefas(new DateTime(2019, 1, 1));
            var handler = new GerenciaPrazoDasTarefasHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            var tarefasEmAtraso = repo.ObtemTarefas(t => t.Status == StatusTarefa.EmAtraso);
            Assert.Equal(5, tarefasEmAtraso.Count());
        }
    }
}


/**
 * Dublês para Testes
 * 
 * Dummy Object: são objetos que eu tenho que criar, mas que não são utilizados no assert. Neste teste, tenho como exemplos as categorias.
 * Fake Object: são classes que eu crio/uso para simular um recurso, de forma leve. Por exemplo, o repositório fake e o inMemoryDatabase
 */
