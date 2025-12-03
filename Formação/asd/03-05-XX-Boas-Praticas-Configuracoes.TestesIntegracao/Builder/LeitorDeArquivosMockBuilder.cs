using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Arquivos;
using Moq;

namespace _03_05_XX_Boas_Praticas_Configuracoes.TestesIntegracao.Builder;

internal static class LeitorDeArquivosMockBuilder
{
    public static Mock<PetsDoCsv> GetMock(List<Pet> listaDePet)
    {
        var leitorDeArquivo = new Mock<PetsDoCsv>(MockBehavior.Default,
            It.IsAny<string>());

        leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

        return leitorDeArquivo;
    }
}