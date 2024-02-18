﻿using _03_06_XX_Enviando_Email.Console.Comandos;

namespace _03_06_XX_Enviando_Email.Testes.Comandos;

public class FabricaDeComandosTest
{
    [Fact]
    public void DadoUmParametroDeveRetornarUmTipoImport()
    {
        //Arrange
        string[] args = { "import", "lista.csv" };
        //Act
        var comando = ComandosFactory.CriarComando(args);
        //Assert
        Assert.IsType<Import>(comando);
    }

    [Fact]
    public void DadoUmParametroDeveRetornarUmTipoList()
    {
        //Arrange
        string[] args = { "list", "lista.csv" };
        //Act
        var comando = ComandosFactory.CriarComando(args);
        //Assert
        Assert.IsType<List>(comando);
    }

    [Fact]
    public void DadoUmParametroInvalidoDeveRetornarNulo()
    {
        //Arrange
        string[] args = { "invalid", "lista.csv" };
        //Act
        var comando = ComandosFactory.CriarComando(args);
        //Assert
        Assert.Null(comando);
    }

    [Fact]
    public void DadoUmArrayDeArgumentosNuloDeveRetornarNulo()
    {
        //Arrange
        //Act
        var comando = ComandosFactory.CriarComando(null);
        //Assert
        Assert.Null(comando);
    }

    [Fact]
    public void DadoUmArrayDeArgumentosVazioDeveRetornarNulo()
    {
        //Arrange
        string[] args = { };
        //Act
        var comando = ComandosFactory.CriarComando(args);
        //Assert
        Assert.Null(comando);
    }
}