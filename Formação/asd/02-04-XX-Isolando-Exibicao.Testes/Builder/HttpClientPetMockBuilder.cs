using _02_04_XX_Isolando_Exibicao.Console.Servicos;
using Moq;

namespace _02_04_XX_Isolando_Exibicao.Testes.Builder
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