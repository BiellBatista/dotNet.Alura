using _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos.Import;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Http;
using _03_05_XX_Boas_Praticas_Configuracoes.TestesIntegracao.Builder;

namespace _03_05_XX_Boas_Praticas_Configuracoes.TestesIntegracao;

public class ImportIntegrationTest
{
    [Fact]
    public async void QuandoAPIEstaNoArDeveRetornarListaDePet()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
              "Lima", TipoPet.Cachorro); //"456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
        listaDePet.Add(pet);
        var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePet);
        var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory("http://localhost:5057").CreateClient("adopet"));
        var import = new Import(httpClientPet, leitorDeArquivo.Object);

        //Act
        await import.ExecutarAsync();

        //Assert
        var listaPet = await httpClientPet.ListAsync();
        Assert.NotNull(listaPet);
    }
}