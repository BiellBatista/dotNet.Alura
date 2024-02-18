using _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos.Import;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Extensions;
using System.Reflection;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Testes.Extensions;

public class ComandoExtensionsTest
{
    [Theory]
    [InlineData("import", "Import")]
    [InlineData("import-clientes", "ImportClientes")]
    [InlineData("show", "Show")]
    [InlineData("list", "List")]
    [InlineData("help", "Help")]
    public void QuandoInstrucaoForSuportadaDeveRetornarTipoDeComando(string instrucao, string nomeClasse)
    {
        // arrange
        Assembly assemblyASerVerificada = Assembly.GetAssembly(typeof(Import))!;

        // act
        Type? tipoRetornado = assemblyASerVerificada.GetTipoDoComando(instrucao);

        // assert
        Assert.NotNull(tipoRetornado);
        Assert.Equal(nomeClasse, tipoRetornado.Name);
    }

    [Fact]
    public void QuandoInstrucaoNaoSuportadaDeveRetornarNulo()
    {
        // arrange
        Assembly assemblyASerVerificada = Assembly.GetAssembly(typeof(Import))!;

        // act
        Type? tipoRetornado = assemblyASerVerificada.GetTipoDoComando("qualquer coisa");

        // assert
        Assert.Null(tipoRetornado);
    }
}