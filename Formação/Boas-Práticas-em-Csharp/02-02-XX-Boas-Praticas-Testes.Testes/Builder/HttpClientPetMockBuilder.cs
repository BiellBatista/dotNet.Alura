using _02_02_XX_Boas_Praticas_Testes.Console.Servicos;
using Moq;

namespace _02_02_XX_Boas_Praticas_Testes.Testes.Builder
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