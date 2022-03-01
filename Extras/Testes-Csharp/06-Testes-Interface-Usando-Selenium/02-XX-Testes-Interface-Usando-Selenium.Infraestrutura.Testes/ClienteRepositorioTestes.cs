using _02_XX_Testes_Interface_Usando_Selenium.Dados.Repositorio;
using _02_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades;
using _02_XX_Testes_Interface_Usando_Selenium.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace _02_XX_Testes_Interface_Usando_Selenium.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteRepositorioTestes()
        {
            var servico = new ServiceCollection();

            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();

            var provider = servico.BuildServiceProvider();

            _repositorio = provider.GetService<IClienteRepositorio>();
        }

        [Fact]
        public void TestaObterTodosClientes()
        {
            //Arrange
            //Act
            List<Cliente> lista = _repositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);
            Assert.NotEmpty(lista);
        }

        [Fact]
        public void TestaObterClientesPorId()
        {
            //Arrange
            //Act
            var cliente = _repositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(cliente);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void TestaObterClientesPorVariosId(int id)
        {
            //Arrange
            //Act
            var cliente = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(cliente);
        }

        [Fact]
        public void TestaAtualizacaoInformacaoDeterminadoCliente()
        {
            //Arrange
            var cliente = _repositorio.ObterPorId(2);
            var nomeNovo = "João Pedro";
            cliente.Nome = nomeNovo;

            //Act
            var atualizado = _repositorio.Atualizar(2, cliente);

            //Assert
            Assert.True(atualizado);
        }

        // Testes com Mock
        [Fact]
        public void TestaObterClientesMock()
        {
            //Arange
            var bytebankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = bytebankRepositorioMock.Object;

            //Act
            var lista = mock.BuscarClientes();

            //Assert
            bytebankRepositorioMock.Verify(b => b.BuscarClientes());
        }
    }
}