using _03_05_XX_Boas_Praticas_Configuracoes.Console.Atributos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Util;
using System.Reflection;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Testes.Util;

public class GeraDocumentacaoTest
{
    [Fact]
    public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
    {
        //Arrange
        Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComandoAttribute))!;

        //Act
        Dictionary<string, DocComandoAttribute> dicionario =
              DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);

        //Assert
        Assert.NotNull(dicionario);
        Assert.NotEmpty(dicionario);
        Assert.Equal(5, dicionario.Count);
    }

    [Theory]
    [InlineData("help", true)]
    [InlineData("show", true)]
    [InlineData("list", true)]
    [InlineData("import", true)]
    [InlineData("import-clientes", true)]
    [InlineData("lixo", false)]
    [InlineData("", false)]
    [InlineData("   ", false)]
    public void DadaInstrucaoValidaDeveExistirNoDicionario(string instrucao, bool valido)
    {
        //Arrange
        Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComandoAttribute))!;

        //Act
        Dictionary<string, DocComandoAttribute> dicionario =
              DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);

        //Assert
        Assert.NotNull(dicionario);
        Assert.NotEmpty(dicionario);
        Assert.Equal(valido, dicionario.ContainsKey(instrucao));
    }
}