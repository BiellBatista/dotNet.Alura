using _03_03_XX_Importacao_Clientes.Console.Comandos;
using _03_03_XX_Importacao_Clientes.Console.Modelos;
using _03_03_XX_Importacao_Clientes.Console.Results;
using _03_03_XX_Importacao_Clientes.Testes.Builder;

namespace _03_03_XX_Importacao_Clientes.Testes.Comandos;

public class ImportClientesTest
{
    [Fact]
    public async Task QuandoClienteEstiverNoArquivoDeveSerImportado()
    {
        //Arrange
        List<Cliente> listaDeClientes = new();
        var cliente = new Cliente(
            id: new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
            nome: "Jeni Entity",
            email: "jeni@example.org"
        );
        listaDeClientes.Add(cliente);

        var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDeClientes);

        var mockService = ApiServiceMockBuilder.GetMock<Cliente>();

        var import = new ImportClientes(mockService.Object, leitorDeArquivo.Object);

        //Act
        var resultado = await import.ExecutarAsync();

        //Assert
        Assert.True(resultado.IsSuccess);
        var sucesso = (SuccessWithClientes)resultado.Successes[0];
        Assert.Equal("Jeni Entity", sucesso.Data.First().Nome);
    }
}