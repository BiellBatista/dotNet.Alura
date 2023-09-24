using _05_XX_Fabrica_Comandos.Console.Comandos;
using _05_XX_Fabrica_Comandos.Console.Modelos;
using _05_XX_Fabrica_Comandos.Console.Servicos;
using _05_XX_Fabrica_Comandos.Testes.Builder;

namespace _05_XX_Fabrica_Comandos.Testes
{
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
            var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
            var import = new Import(httpClientPet, leitorDeArquivo.Object);

            //Act
            await import.ExecutarAsync();

            //Assert
            var listaPet = await httpClientPet.ListPetsAsync();
            Assert.NotNull(listaPet);
        }
    }
}