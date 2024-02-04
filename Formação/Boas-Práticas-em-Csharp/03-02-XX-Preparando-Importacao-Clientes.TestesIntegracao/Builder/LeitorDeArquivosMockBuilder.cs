using _03_02_XX_Preparando_Importacao_Clientes.Console.Modelos;
using _03_02_XX_Preparando_Importacao_Clientes.Console.Servicos.Arquivos;
using Moq;

namespace _03_02_XX_Preparando_Importacao_Clientes.TestesIntegracao.Builder;

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