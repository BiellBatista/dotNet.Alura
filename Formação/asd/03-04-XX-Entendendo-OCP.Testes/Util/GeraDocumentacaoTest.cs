using _03_04_XX_Entendendo_OCP.Console.Atributos;
using _03_04_XX_Entendendo_OCP.Console.Util;
using System.Reflection;

namespace _03_04_XX_Entendendo_OCP.Testes.Util;

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
}