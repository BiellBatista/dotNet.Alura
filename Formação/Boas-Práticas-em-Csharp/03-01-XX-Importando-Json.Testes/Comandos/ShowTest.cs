﻿using _03_01_XX_Importando_Json.Console.Comandos;
using _03_01_XX_Importando_Json.Console.Modelos;
using _03_01_XX_Importando_Json.Console.Results;
using _03_01_XX_Importando_Json.Testes.Builder;

namespace _03_01_XX_Importando_Json.Testes.Comandos;

public class ShowTest
{
    [Fact]
    public async Task QuandoArquivoExistenteDeveRetornarMensagemDeSucesso()
    {
        //Arrange
        List<Pet> listaDePet = new();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                          "Lima", TipoPet.Cachorro);
        listaDePet.Add(pet);
        var leitor = LeitorDeArquivosMockBuilder.GetMock(listaDePet);
        leitor.Setup(_ => _.RealizaLeitura());

        var show = new Show(leitor.Object);

        //Act
        var resultado = await show.ExecutarAsync();

        //Assert
        Assert.NotNull(resultado);
        var sucesso = (SuccessWithPets)resultado.Successes[0];
        Assert.Equal("Exibição do arquivo realizada com sucesso!",
            sucesso.Message);
    }
}