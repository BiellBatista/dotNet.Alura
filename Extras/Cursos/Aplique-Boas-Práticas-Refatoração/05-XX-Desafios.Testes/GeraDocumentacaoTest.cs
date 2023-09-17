using _05_XX_Desafios.Console.Comandos;
using _05_XX_Desafios.Console.Util;
using System.Reflection;

namespace _05_XX_Desafios.Testes;

public class GeraDocumentacaoTest
{
    [Fact]
    public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
    {
        // arrange
        Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComando))!;
        // porque pus o !: como fiz referência ao projeto que contém DocComando, garanto que não é nulo

        // act
        var dicionario = DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);

        // assert
        Assert.NotNull(dicionario);
        Assert.NotEmpty(dicionario);
        Assert.Equal(4, dicionario.Count);
    }
}