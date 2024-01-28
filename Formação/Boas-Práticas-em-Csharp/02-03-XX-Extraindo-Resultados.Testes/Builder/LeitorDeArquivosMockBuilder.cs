using _02_03_XX_Extraindo_Resultados.Console.Modelos;
using _02_03_XX_Extraindo_Resultados.Console.Util;
using Moq;

namespace _02_03_XX_Extraindo_Resultados.Testes.Builder
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