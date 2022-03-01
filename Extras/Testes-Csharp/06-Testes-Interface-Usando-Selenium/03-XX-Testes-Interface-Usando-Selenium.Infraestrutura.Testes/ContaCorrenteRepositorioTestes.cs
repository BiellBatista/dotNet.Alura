using _03_XX_Testes_Interface_Usando_Selenium.Dados.Repositorio;
using _03_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades;
using _03_XX_Testes_Interface_Usando_Selenium.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace _03_XX_Testes_Interface_Usando_Selenium.Infraestrutura.Testes
{
    public class ContaCorrenteRepositorioTestes
    {
        private readonly IContaCorrenteRepositorio _repositorio;

        public ContaCorrenteRepositorioTestes()
        {
            var servico = new ServiceCollection();

            servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();

            var provider = servico.BuildServiceProvider();

            _repositorio = provider.GetService<IContaCorrenteRepositorio>();
        }

        [Fact]
        public void TestaObterTodasContasCorrentes()
        {
            //Arrange
            //Act
            List<ContaCorrente> lista = _repositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);
        }

        [Fact]
        public void TestaObterContaCorrentePorId()
        {
            //Arrange
            //Act
            var conta = _repositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(conta);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TestaObterContasCorrentesPorVariosId(int id)
        {
            //Arrange
            //Act
            var conta = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(conta);
        }

        [Fact]
        public void TestaAtualizaSaldoDeterminadaConta()
        {
            //Arrange
            var conta = _repositorio.ObterPorId(2);
            double saldoNovo = 15;
            conta.Saldo = saldoNovo;

            //Act
            var atualizado = _repositorio.Atualizar(2, conta);

            //Assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaInsereUmaNovaContaCorrenteNoBancoDeDados()
        {
            //Arrange
            var conta = new ContaCorrente()
            {
                Saldo = 10,
                Id = 1,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Nome = "Bruce Kent",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Empresário",
                    Id = 1
                },
                Agencia = new Agencia()
                {
                    Nome = "Agencia Central 1",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Rua das Flores,25",
                    Numero = 147
                }
            };

            //Act
            var adicionado = _repositorio.Adicionar(conta);

            //Assert
            Assert.True(adicionado);
        }

        // Testes com Mock
        [Fact]
        public void TestaObterContasMock()
        {
            //Arange
            var bytebankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = bytebankRepositorioMock.Object;

            //Act
            var lista = mock.BuscarContasCorrentes();

            //Assert - Verificando o comportamento
            bytebankRepositorioMock.Verify(b => b.BuscarContasCorrentes());
        }

        [Fact]
        public void TestaConsultaPixMock()
        {
            //Arange
            var pixRepositorioMock = new Mock<IPixRepositorio>();
            var mock = pixRepositorioMock.Object;

            //Act
            var lista = mock.consultaPix(new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a"));

            //Assert - Verificando o comportamento
            pixRepositorioMock.Verify(b => b.consultaPix(new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a")));
        }
    }
}