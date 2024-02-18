using _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos.ImportClientes;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Results;
using _03_05_XX_Boas_Praticas_Configuracoes.Testes.Builder;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Testes.Comandos;

public class ImportClientesTest
{
    [Fact]
    public async Task QuandoClienteEstiverNoArquivoDeveSerImportado()
    {
        //Arrange
        List<Cliente> listaDeClientes = new();
        var cliente = new Cliente(
            id: new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
            nome: "André",
            email: "andre@email.org");
        listaDeClientes.Add(cliente);

        var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDeClientes);

        var service = ApiServiceMockBuilder.GetMock<Cliente>();

        var import = new ImportClientes(service.Object, leitorDeArquivo.Object);

        //Act
        var resultado = await import.ExecutarAsync();

        //Assert
        Assert.True(resultado.IsSuccess);
        var sucesso = (SuccessWithClientes)resultado.Successes[0];
        Assert.Equal("André", sucesso.Data.First().Nome);
    }
}