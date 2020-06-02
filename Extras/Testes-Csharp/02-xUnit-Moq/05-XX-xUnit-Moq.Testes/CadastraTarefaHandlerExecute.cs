using _05_XX_xUnit_Moq.Core.Commands;
using _05_XX_xUnit_Moq.Core.Models;
using _05_XX_xUnit_Moq.Infrastructure;
using _05_XX_xUnit_Moq.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace _05_XX_xUnit_Moq.Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void DadaTarefaComInfoValidasDeveIncluirNoBD()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(context);

            var mock = new Mock<ILogger<CadastraTarefaHandler>>();

            var handler = new CadastraTarefaHandler(repo, mock.Object);

            //act
            handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute

            //assert
            var tarefa = repo.ObtemTarefas(t => t.Titulo == "Estudar Xunit").FirstOrDefault();
            Assert.NotNull(tarefa);
        }

        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalso()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var mock = new Mock<IRepositorioTarefas>(); //mocando o objeto a ser criado

            //configurando o objeto, no meu caso, criando a exceção
            // quando vc criar o método "IncluirTarefas", lance a exceção..
            //mock faz um setup para quando o método IncluirTarefas for chamado para qualquer algumento de entrada (do tipo Tarefa)..
            //lance a exceçõa..
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>())).Throws(new Exception("Houve um erro na inclusão de tarefas"));

            var repo = mock.Object; //falando para o mock me dar o objeto que foi mocado e configurado em cima
            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            Assert.False(resultado.IsSuccess);
        }

        [Fact]
        public void QuandoExceptionForLancadaDeveLogarAMensagemDaExcecao()
        {
            //arrange
            var mensagemDeErroEsperada = "Houve um erro na inclusão de tarefas";
            var excecaoEsperada = new Exception(mensagemDeErroEsperada);
            var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var mock = new Mock<IRepositorioTarefas>(); //mocando o objeto a ser criado

            //configurando o objeto, no meu caso, criando a exceção
            // quando vc criar o método "IncluirTarefas", lance a exceção..
            //mock faz um setup para quando o método IncluirTarefas for chamado para qualquer algumento de entrada (do tipo Tarefa)..
            //lance a exceçõa..
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>())).Throws(excecaoEsperada);

            var repo = mock.Object; //falando para o mock me dar o objeto que foi mocado e configurado em cima
            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            // não consigo utilizar a verificação do mock, em métodos de extensoes
            //mockLogger.Verify(l => l.LogError(mensagemDeErroEsperada), Times.Once());
            mockLogger.Verify(l => l.Log(
                LogLevel.Error, // nível de log
                It.IsAny<EventId>(), // identificador do evento
                It.IsAny<object>(), // objeto que será logado (mensagem)
                excecaoEsperada, // excecao que será logada (já está com a mensagem)
                It.IsAny<Func<object, Exception, string>>()), // funcao que converte o objeto e a excecao em uma string
                Times.Once());
        }
    }
}
// não consigo utilizar a verificação do mock, em métodos de extensoes
/**
 * Dublês para Testes
 * 
 * Dummy Object: são objetos que eu tenho que criar, mas que não são utilizados no assert. Neste teste, tenho como exemplos as categorias.
 * Fake Object: são classes que eu crio/uso para simular um recurso, de forma leve. Por exemplo, o repositório fake e o inMemoryDatabase.
 * Stubs: é um objeto do qual eu preciso fornecer alguma informação de entrada para o teste. Por exemplo, o lançamento de uma exceção, porque foi preciso
 *  mockar um objeto (simular). Em resumo, ele simula um objeto, do qual é necessário fornecer informação
 */
