using _03_01_XX_Importando_Json.Console.Modelos;
using _03_01_XX_Importando_Json.Console.Servicos.Arquivos;
using Moq;

namespace _03_01_XX_Importando_Json.Testes.Builder;

internal static class LeitorDeArquivosMockBuilder
{
    public static Mock<LeitorDeArquivoCsv> GetMock(List<Pet> listaDePet)
    {
        var leitorDeArquivo = new Mock<LeitorDeArquivoCsv>(MockBehavior.Default,
            It.IsAny<string>());

        leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

        return leitorDeArquivo;
    }
}