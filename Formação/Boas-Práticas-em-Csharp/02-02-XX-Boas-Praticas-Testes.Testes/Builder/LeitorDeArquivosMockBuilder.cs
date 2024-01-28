using _02_02_XX_Boas_Praticas_Testes.Console.Modelos;
using _02_02_XX_Boas_Praticas_Testes.Console.Util;
using Moq;

namespace _02_02_XX_Boas_Praticas_Testes.Testes.Builder
{
    internal static class LeitorDeArquivosMockBuilder
    {
        public static Mock<LeitorDeArquivo> GetMock(List<Pet> listaDePet)
        {
            var leitorDeArquivo = new Mock<LeitorDeArquivo>(MockBehavior.Default,
                It.IsAny<string>());

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

            return leitorDeArquivo;
        }
    }
}