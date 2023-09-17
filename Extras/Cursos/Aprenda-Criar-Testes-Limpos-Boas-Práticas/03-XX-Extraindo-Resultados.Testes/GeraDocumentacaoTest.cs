using _03_XX_Extraindo_Resultados.Console.Comandos;
using _03_XX_Extraindo_Resultados.Console.Util;
using System.Reflection;

namespace _03_XX_Extraindo_Resultados.Testes
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