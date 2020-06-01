using _04_XX_xUnit_Moq.Core.Commands;
using _04_XX_xUnit_Moq.Core.Models;
using _04_XX_xUnit_Moq.Infrastructure;
using _04_XX_xUnit_Moq.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using Moq;

namespace _04_XX_xUnit_Moq.Testes
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

            var handler = new CadastraTarefaHandler(repo);

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

            var mock = new Mock<IRepositorioTarefas>(); //mocando o objeto a ser criado

            //configurando o objeto, no meu caso, criando a exceção
            // quando vc criar o método "IncluirTarefas", lance a exceção..
            //mock faz um setup para quando o método IncluirTarefas for chamado para qualquer algumento de entrada (do tipo Tarefa)..
            //lance a exceçõa..
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>())).Throws(new Exception("Houve um erro na inclusão de tarefas"));

            var repo = mock.Object; //falando para o mock me dar o objeto que foi mocado e configurado em cima
            var handler = new CadastraTarefaHandler(repo);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            Assert.False(resultado.IsSuccess);
        }
    }
}

/**
 * Dublês para Testes
 * 
 * Dummy Object: são objetos que eu tenho que criar, mas que não são utilizados no assert. Neste teste, tenho como exemplos as categorias.
 * Fake Object: são classes que eu crio/uso para simular um recurso, de forma leve. Por exemplo, o repositório fake e o inMemoryDatabase.
 * Stubs: é um objeto do qual eu preciso fornecer alguma informação de entrada para o teste. Por exemplo, o lançamento de uma exceção, porque foi preciso
 *  mockar um objeto (simular). Em resumo, ele simula um objeto, do qual é necessário fornecer informação
 */
