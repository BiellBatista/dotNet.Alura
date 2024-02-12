﻿using _03_03_XX_Importacao_Clientes.Console.Servicos.Abstracoes;
using Moq;

namespace _03_03_XX_Importacao_Clientes.Testes.Builder;

internal static class ApiServiceMockBuilder
{
    public static Mock<IApiService<T>> GetMock<T>()
    {
        return new Mock<IApiService<T>>(MockBehavior.Default);
    }

    public static Mock<IApiService<T>> GetMockList<T>(List<T> lista)
    {
        var mockService = new Mock<IApiService<T>>(MockBehavior.Default);
        mockService.Setup(_ => _.ListAsync())
            .ReturnsAsync(lista);
        return mockService;
    }
}