﻿using _01_05_XX_Desafios.Console.Util;

namespace _01_05_XX_Desafios.Testes;

public class PetAPartirDoCsvTest
{
    // null, vazia, qtde insuficiente de campos, guid inválido, tipo inválido
    [Fact]
    public void QuandoStringForValidaDeveRetornatUmPet()
    {
        //Arrange
        string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

        //Act
        var pet = linha.ConverteDoTexto();

        //Assert
        Assert.NotNull(pet);
    }

    [Fact]
    public void QuandoStringNulaDeveLancarArgumentNullException()
    {
        // arrange
        string? linha = null;

        // act + assert
        Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
    }

    [Fact]
    public void QuandoStringVaziaDeveLancarArgumentException()
    {
        // arrange
        string? linha = string.Empty;

        // act + assert
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }

    [Fact]
    public void QuandoCamposInsuficientesDeveLancarArgumentException()
    {
        // arrange
        string? linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão";

        // act + assert
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }

    [Fact]
    public void QuandoGuidInvalidoDeveLancarArgumentException()
    {
        // arrange
        string? linha = "adkajhd;Lima Limão;1";

        // act + assert
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }

    [Fact]
    public void QuandoTipoInvalidoDeveLancarArgumentException()
    {
        // arrange
        string? linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;2";

        // act + assert
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }
}