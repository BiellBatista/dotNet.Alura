﻿using _02_XX_Testes_Interface_Usando_Selenium.Dados.Repositorio;
using _02_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace _02_XX_Testes_Interface_Usando_Selenium.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {
        private ClienteRepositorio _repositorio;

        [Fact]
        public void TestaObterTodosClientes()
        {
            //Arrange
            _repositorio = new ClienteRepositorio();

            //Act
            List<Cliente> lista = _repositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);
        }

        [Fact]
        public void TestaObterClientesPorId()
        {
            //Arrange
            _repositorio = new ClienteRepositorio();

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
            _repositorio = new ClienteRepositorio();

            //Act
            var cliente = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(cliente);
        }

        [Fact]
        public void TestaAtualizacaoInformacaoDeterminadoCliente()
        {
            //Arrange
            _repositorio = new ClienteRepositorio();
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