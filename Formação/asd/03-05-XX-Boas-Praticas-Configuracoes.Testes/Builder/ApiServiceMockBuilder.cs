using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;
using Moq;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Testes.Builder;

internal static class ApiServiceMockBuilder
{
    public static Mock<IApiService<T>> GetMock<T>()
    {
        return new Mock<IApiService<T>>(MockBehavior.Default);
    }

    public static Mock<IApiService<T>> GetMockList<T>(List<T> lista)
    {
        var service = new Mock<IApiService<T>>(MockBehavior.Default);
        service.Setup(_ => _.ListAsync()).ReturnsAsync(lista);
        return service;
    }
}