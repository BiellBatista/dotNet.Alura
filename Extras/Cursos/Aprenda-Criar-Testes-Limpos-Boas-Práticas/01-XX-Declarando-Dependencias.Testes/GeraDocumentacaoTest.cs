using _01_XX_Declarando_Dependencias.Console.Comandos;
using _01_XX_Declarando_Dependencias.Console.Util;
using System.Reflection;

namespace _01_XX_Declarando_Dependencias.Testes
{
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
}