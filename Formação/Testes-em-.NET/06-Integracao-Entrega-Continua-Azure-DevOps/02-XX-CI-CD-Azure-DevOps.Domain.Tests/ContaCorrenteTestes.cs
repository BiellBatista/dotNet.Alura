﻿using _02_XX_CI_CD_Azure_DevOps.Domain.Entidades;
using Xunit;

namespace _02_XX_CI_CD_Azure_DevOps.Domain.Tests
{
    public class ContaCorrenteTestes
    {
        [Fact]
        public void CriarContaCorrenteValida()
        {
            //Arrange
            float saldo = 50;
            Guid identificador = Guid.NewGuid();
            int id = 1;
            var cliente = new Cliente();
            var agencia = new Agencia();

            //Act
            var contacorrente = new ContaCorrente()
            {
                Saldo = saldo,
                Id = id,
                Identificador = identificador,
                Cliente = cliente,
                Agencia = agencia
            };

            //Assert
            Assert.Equal(saldo + 100, contacorrente.Saldo);
            Assert.Equal(id, contacorrente.Id);
            Assert.Equal(identificador, contacorrente.Identificador);
            Assert.NotNull(contacorrente.Agencia);
            Assert.NotNull(contacorrente.Cliente);
        }

        [Fact]
        public void TestaExceptionValorDeSaldoMenorIgualAzero()
        {
            //Arrange
            int numeroInvalido = -1230;
            //Act
            //Assert
            Assert.Throws<Exception>(
                () => new ContaCorrente().Saldo = numeroInvalido
             );
        }
    }
}