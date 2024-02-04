using _03_02_XX_Preparando_Importacao_Clientes.Console.Atributos;
using _03_02_XX_Preparando_Importacao_Clientes.Console.Util;
using System.Reflection;

namespace _03_02_XX_Preparando_Importacao_Clientes.Testes.Util;

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
        Assert.Equal(4, dicionario.Count);
    }
}