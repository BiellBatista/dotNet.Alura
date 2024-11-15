﻿using _01_04_XX_Testes_Automatizados.Console.Util;

namespace _01_04_XX_Testes_Automatizados.Testes;

public class PetAPartirDoCsvTest
{
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
}