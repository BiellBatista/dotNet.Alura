using _03_06_XX_Enviando_Email.Console.Servicos.Abstracoes;
using Moq;

namespace _03_06_XX_Enviando_Email.Testes.Builder;

internal static class LeitorDeArquivosMockBuilder
{
    public static Mock<ILeitorDeArquivos<T>> GetMock<T>(List<T> lista)
    {
        var leitorDeArquivo = new Mock<ILeitorDeArquivos<T>>(MockBehavior.Default
            );

        leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(lista);

        return leitorDeArquivo;
    }
}