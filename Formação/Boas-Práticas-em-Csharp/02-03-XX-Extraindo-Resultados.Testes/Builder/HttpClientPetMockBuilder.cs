using _02_03_XX_Extraindo_Resultados.Console.Servicos;
using Moq;

namespace _02_03_XX_Extraindo_Resultados.Testes.Builder
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