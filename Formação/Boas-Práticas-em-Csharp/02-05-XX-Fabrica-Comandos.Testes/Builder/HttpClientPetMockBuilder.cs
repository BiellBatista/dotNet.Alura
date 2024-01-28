using _02_05_XX_Fabrica_Comandos.Console.Servicos;
using Moq;

namespace _02_05_XX_Fabrica_Comandos.Testes.Builder
{
    internal static class HttpClientPetMockBuilder
    {
        public static Mock<HttpClientPet> GetMock()
        {
            var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default,
                It.IsAny<HttpClient>());

            return httpClientPet;

            ;
        }
    }
}