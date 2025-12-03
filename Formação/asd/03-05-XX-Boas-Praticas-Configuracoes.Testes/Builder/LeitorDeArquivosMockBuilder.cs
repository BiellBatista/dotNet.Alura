using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;
using Moq;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Testes.Builder;

internal static class LeitorDeArquivosMockBuilder
{
    public static Mock<ILeitorDeArquivo<T>> GetMock<T>(List<T> lista)
    {
        var leitorDeArquivo = new Mock<ILeitorDeArquivo<T>>(MockBehavior.Default);

        leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(lista);

        return leitorDeArquivo;
    }
}