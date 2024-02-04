using _03_01_XX_Importando_Json.Console.Modelos;
using _03_01_XX_Importando_Json.Console.Servicos.Http;
using Moq;

namespace _03_01_XX_Importando_Json.Testes.Builder;

internal static class HttpClientPetMockBuilder
{
    public static Mock<HttpClientPet> GetMock()
    {
        var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default,
            It.IsAny<HttpClient>());
        return httpClientPet;
    }

    public static Mock<HttpClientPet> GetMockList(List<Pet> lista)
    {
        var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default,
            It.IsAny<HttpClient>());
        httpClientPet.Setup(_ => _.ListAsync())
            .ReturnsAsync(lista);
        return httpClientPet;
    }
}