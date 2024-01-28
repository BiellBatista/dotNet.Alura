using _02_02_XX_Boas_Praticas_Testes.Console.Comandos;
using _02_02_XX_Boas_Praticas_Testes.Console.Util;
using System.Reflection;

namespace _02_02_XX_Boas_Praticas_Testes.Testes
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