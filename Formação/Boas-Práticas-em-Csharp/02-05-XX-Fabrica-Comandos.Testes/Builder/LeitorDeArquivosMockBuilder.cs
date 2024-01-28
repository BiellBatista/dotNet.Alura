using _05_XX_Fabrica_Comandos.Console.Modelos;
using _05_XX_Fabrica_Comandos.Console.Util;
using Moq;

namespace _05_XX_Fabrica_Comandos.Testes.Builder
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