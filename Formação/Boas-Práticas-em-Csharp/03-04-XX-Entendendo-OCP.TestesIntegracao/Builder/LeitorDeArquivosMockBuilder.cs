using _03_04_XX_Entendendo_OCP.Console.Modelos;
using _03_04_XX_Entendendo_OCP.Console.Servicos.Arquivos;
using Moq;

namespace _03_04_XX_Entendendo_OCP.TestesIntegracao.Builder;

internal static class LeitorDeArquivosMockBuilder
{
    public static Mock<LeitorDeArquivoCsv<Pet>> GetMock(List<Pet> listaDePet)
    {
        var leitorDeArquivo = new Mock<LeitorDeArquivoCsv<Pet>>(MockBehavior.Default,
            It.IsAny<string>());

        leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

        return leitorDeArquivo;
    }
}