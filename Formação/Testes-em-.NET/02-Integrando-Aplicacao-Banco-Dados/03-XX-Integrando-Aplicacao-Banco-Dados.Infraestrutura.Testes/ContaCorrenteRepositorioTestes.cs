﻿using _03_XX_Integrando_Aplicacao_Banco_Dados.Dados.Repositorio;
using _03_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Entidades;
using _03_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;

namespace _03_XX_Integrando_Aplicacao_Banco_Dados.Infraestrutura.Testes
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

            var conta = _repositorio.ObterPorId(1);
            double saldoNovo = 15;
            conta.Saldo = saldoNovo;

            //Act
            var atualizado = _repositorio.Atualizar(1, conta);

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
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Nome = "Kent Nelson",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Bancário",
                    Id = 1
                },
                Agencia = new Agencia()
                {
                    Nome = "Agencia Central Coast City",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Rua das Flores,25",
                    Numero = 147
                }
            };

            //Act
            var retorno = _repositorio.Adicionar(conta);

            //Assert
            Assert.True(retorno);
        }
    }
}