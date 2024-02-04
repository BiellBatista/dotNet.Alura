﻿using _03_02_XX_Preparando_Importacao_Clientes.Console.Comandos;
using _03_02_XX_Preparando_Importacao_Clientes.Console.Modelos;
using _03_02_XX_Preparando_Importacao_Clientes.Console.Results;
using _03_02_XX_Preparando_Importacao_Clientes.Testes.Builder;
using Moq;

namespace _03_02_XX_Preparando_Importacao_Clientes.Testes.Comandos;

public class ImportTest
{
    [Fact]
    public async void QuandoListaVaziaNaoDeveChamarCreatPetAsync()
    {
        //Arrange
        List<Pet> listaDePet = new();
        var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePet);

        var httpClientPet = HttpClientPetMockBuilder.GetMock();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

        //Act
        await import.ExecutarAsync();

        //Assert
        httpClientPet.Verify(_ => _.CreateAsync(It.IsAny<Pet>()), Times.Never);
    }

    [Fact]
    public async Task QuandoArquivoNaoExistenteDeveGerarFalha()
    {
        //Arrange
        List<Pet> listaDePet = new();
        var leitor = LeitorDeArquivosMockBuilder.GetMock(listaDePet);
        leitor.Setup(_ => _.RealizaLeitura()).Throws<FileNotFoundException>();

        var httpClientPet = HttpClientPetMockBuilder.GetMock();

        var import = new Import(httpClientPet.Object, leitor.Object);

        //Act
        var resultado = await import.ExecutarAsync();

        //Assert
        Assert.True(resultado.IsFailed);
    }

    [Fact]
    public async Task QuandoPetEstiverNoArquivoDeveSerImportado()
    {
        //Arrange
        List<Pet> listaDePet = new();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                          "Lima", TipoPet.Cachorro);
        listaDePet.Add(pet);
        var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePet);

        var httpClientPet = HttpClientPetMockBuilder.GetMock();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

        //Act
        var resultado = await import.ExecutarAsync();

        //Assert
        Assert.True(resultado.IsSuccess);
        var sucesso = (SuccessWithPets)resultado.Successes[0];
        Assert.Equal("Lima", sucesso.Data.First().Nome);
    }
}