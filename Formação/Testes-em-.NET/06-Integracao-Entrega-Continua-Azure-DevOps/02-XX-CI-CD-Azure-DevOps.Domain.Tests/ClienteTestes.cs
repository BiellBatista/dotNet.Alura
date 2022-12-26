﻿using _02_XX_CI_CD_Azure_DevOps.Domain.Entidades;
using Xunit;

namespace _02_XX_CI_CD_Azure_DevOps.Domain.Tests
{
    public class ClienteTestes
    {
        [Fact]
        public void CriarClienteValido()
        {
            //Arrange
            string nome = "André Silva";
            string cpf = "38506343020";
            Guid identificador = Guid.NewGuid();
            string profissao = "Analista de Sistemas";
            int id = 1;
            //Act
            var cliente = new Cliente()
            {
                Nome = nome,
                CPF = cpf,
                Identificador = identificador,
                Profissao = profissao,
                Id = id
            };
            //Assert
            Assert.Equal(nome, cliente.Nome);
            Assert.Equal(cpf, cliente.CPF);
            Assert.Equal(identificador, cliente.Identificador);
            Assert.Equal(profissao, cliente.Profissao);
            Assert.Equal(id, cliente.Id);
        }

        [Fact]
        public void TestaExcecaoCPFInvalido()
        {
            //Arrange
            string cpfInvalido = "1111111111";
            //Act
            //Assert
            Assert.Throws<FormatException>(
                () => new Cliente().CPF = cpfInvalido
             );
        }

        [Fact]
        public void ValidaNomeClienteNaoPodeSerVazio()
        {
            //Arrange
            string nomeInvalido = string.Empty;
            //Act
            //Assert
            Assert.Throws<FormatException>(
                () => new Cliente().Nome = nomeInvalido
             );
        }

        [Fact]
        public void TestaExcecaoNomeComMenosDe3Caracteres()
        {
            //Arrange
            string nome = "Ab";
            //Act
            //Assert
            Assert.Throws<FormatException>(
                () => new Cliente().Nome = nome
             );
        }
    }
}