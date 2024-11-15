﻿using _03_06_XX_Enviando_Email.Console.Comandos;

namespace _03_06_XX_Enviando_Email.Testes.Comandos;

public class HelpTest
{
    [Fact]
    public async Task QuandoComandoNaoExistirDeveRetornarFalha()
    {
        //Arrange
        var comando = "Inválido";
        var help = new Help(comando);
        //Act
        var resultado = await help.ExecutarAsync();
        //Assert
        Assert.NotNull(resultado);
        Assert.True(resultado.IsFailed);
    }

    [Theory]
    [InlineData("help")]
    [InlineData("show")]
    [InlineData("list")]
    [InlineData("import")]
    public async Task QuandoComandoExistirDeveRetornarSucesso(string comando)
    {
        //Arrange
        var help = new Help(comando);
        //Act
        var resultado = await help.ExecutarAsync();
        //Assert
        Assert.NotNull(resultado);
        Assert.True(resultado.IsSuccess);
    }
}