using _02_04_XX_Isolando_Exibicao.Console.Modelos;
using _02_04_XX_Isolando_Exibicao.Console.Util;
using Moq;

namespace _02_04_XX_Isolando_Exibicao.Testes.Builder
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