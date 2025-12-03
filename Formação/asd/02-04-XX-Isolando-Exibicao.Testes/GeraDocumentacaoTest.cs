using _02_04_XX_Isolando_Exibicao.Console.Comandos;
using _02_04_XX_Isolando_Exibicao.Console.Util;
using System.Reflection;

namespace _02_04_XX_Isolando_Exibicao.Testes
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