﻿using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Arquivos;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Testes.Servicos;

public class LeitorDeArquivoJsonTest : IDisposable
{
    private readonly string caminhoArquivo;

    public LeitorDeArquivoJsonTest()
    {
        string json = @"
            [
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511813e0"",
                ""Nome"": ""Mancha"",
                ""Tipo"": 1
              },
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511672e0"",
                ""Nome"": ""Alvo"",
                ""Tipo"": 1
              },
              {
                ""Id"": ""68286fbf-f6f4-1234-adab-0637511672e0"",
                ""Nome"": ""Pinta"",
                ""Tipo"": 1
              }
            ]
        ";
        File.WriteAllText("lista.json", json);
        caminhoArquivo = Path.GetFullPath("lista.json");
    }

    [Fact]
    public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
    {
        //Arrange

        //Act
        var listaDePets = new PetsDoJson(caminhoArquivo).RealizaLeitura()!;

        //Assert
        Assert.NotNull(listaDePets);
        Assert.Equal(3, listaDePets.Count());
    }

    public void Dispose()
    {
        File.Delete(caminhoArquivo);
    }
}