using System;
using Xunit;
using Moq;
using _06_XX_xUnit_Moq.WebApp.Controllers;
using _06_XX_xUnit_Moq.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _06_XX_xUnit_Moq.Services.Handlers;
using _06_XX_xUnit_Moq.Infrastructure;
using Microsoft.EntityFrameworkCore;
using _06_XX_xUnit_Moq.Core.Models;

namespace _06_XX_xUnit_Moq.Testes
{
    public class TarefasControllerEndPointCadastraTarefa
    {
        [Fact]
        public void DadaTarefaComInformacoesValidasDeveRetornar200()
        {
            //arrange
            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);

            contexto.Categorias.Add(new Core.Models.Categoria(20, "Estudo"));
            contexto.SaveChanges();

            var repo = new RepositorioTarefa(contexto);

            var controlador = new TarefasController(repo, mockLogger.Object);
            var model = new CadastraTarefaVM();

            model.IdCategoria = 20;
            model.Titulo = "Estudar xUnit";
            model.Prazo = new DateTime(2020, 12, 31);

            //act
            var retorno = controlador.EndpointCadastraTarefa(model);

            //assert
            Assert.IsType<OkResult>(retorno);
        }

        [Fact]
        public void QuandoExcecaoForLancadaDeveRetornar500()
        {
            //arrange
            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var mock = new Mock<IRepositorioTarefas>();

            mock.Setup(r => r.ObtemCategoriaPorId(20)).Returns(new Categoria(20, "Estudos"));
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>())).Throws(new Exception("Houve um erro"));

            var repo = mock.Object;

            var controlador = new TarefasController(repo, mockLogger.Object);
            var model = new CadastraTarefaVM();

            model.IdCategoria = 20;
            model.Titulo = "Estudar xUnit";
            model.Prazo = new DateTime(2020, 12, 31);

            //act
            var retorno = controlador.EndpointCadastraTarefa(model);

            //assert
            Assert.IsType<StatusCodeResult>(retorno);
            var statusCodeRetornado = (retorno as StatusCodeResult).StatusCode;
            Assert.Equal(500, statusCodeRetornado);
        }
    }
}

/**
 * Dublês para Testes
 * 
 * Dummy Object: são objetos que eu tenho que criar, mas que não são utilizados no assert. Neste teste, tenho como exemplos as categorias.
 * 
 * Fake Object: são classes que eu crio/uso para simular um recurso, de forma leve. Por exemplo, o repositório fake e o inMemoryDatabase.
 * 
 * Stubs: é um objeto do qual eu preciso fornecer alguma informação de entrada para o teste. Por exemplo, o lançamento de uma exceção, porque foi preciso
 *  mockar um objeto (simular). Em resumo, ele simula um objeto, do qual é necessário fornecer informação
 * 
 * Spys: no spy a gente faz a verificação em um mock indiretamente ligado no teste. Ou seja, estou verificando os efeitos colaterais
 */
