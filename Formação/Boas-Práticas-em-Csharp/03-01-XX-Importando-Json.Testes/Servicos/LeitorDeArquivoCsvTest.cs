﻿using _03_01_XX_Importando_Json.Console.Modelos;
using _03_01_XX_Importando_Json.Console.Servicos.Arquivos;

namespace _03_01_XX_Importando_Json.Testes.Servicos;

public class LeitorDeArquivoCsvTest : IDisposable
{
    private string caminhoArquivo;

    public LeitorDeArquivoCsvTest()
    {
        //Setup
        string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

        string nomeRandomico = $"{Guid.NewGuid()}.csv";

        File.WriteAllText(nomeRandomico, linha);
        caminhoArquivo = Path.GetFullPath(nomeRandomico);
    }

    [Fact]
    public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
    {
        //Arrange
        //Act
        var listaDePets = new LeitorDeArquivoCsv(caminhoArquivo).RealizaLeitura()!;
        //Assert
        Assert.NotNull(listaDePets);
        Assert.Single(listaDePets);
        Assert.IsType<List<Pet>?>(listaDePets);
    }

    [Fact]
    public void QuandoArquivoNaoExistenteDeveRetornarNulo()
    {
        //Arrange
        //Act
        var listaDePets = new LeitorDeArquivoCsv("").RealizaLeitura();
        //Assert
        Assert.Null(listaDePets);
    }

    [Fact]
    public void QuandoArquivoForNuloDeveRetornarNulo()
    {
        //Arrange
        //Act
        var listaDePets = new LeitorDeArquivoCsv(null).RealizaLeitura();
        //Assert
        Assert.Null(listaDePets);
    }

    public void Dispose()
    {
        //ClearDown
        File.Delete(caminhoArquivo);
    }
}