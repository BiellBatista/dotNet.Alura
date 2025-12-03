using _03_03_XX_Importacao_Clientes.Console.Servicos.Abstracoes;
using Moq;

namespace _03_03_XX_Importacao_Clientes.Testes.Builder;

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