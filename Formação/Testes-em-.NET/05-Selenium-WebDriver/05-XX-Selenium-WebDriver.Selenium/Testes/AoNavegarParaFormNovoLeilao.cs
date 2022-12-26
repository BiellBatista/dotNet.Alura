using OpenQA.Selenium;
using Xunit;
using _05_XX_Selenium_WebDriver.Selenium.PageObjects;
using _05_XX_Selenium_WebDriver.Selenium.Fixtures;
using System.Linq;

namespace _05_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaFormNovoLeilao
    {
        private IWebDriver driver;

        public AoNavegarParaFormNovoLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdmDeveMostrarTresCategorias()
        {
            //arrange
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);

            //act
            novoLeilaoPO.Visitar();

            //assert
            Assert.Equal(3, novoLeilaoPO.Categorias.Count());
        }
    }
}
