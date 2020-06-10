using _03_XX_Selenium_WebDriver.Selenium.PageObjects;
using _03_XX_Selenium_WebDriver.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;
using System.Linq;

namespace _03_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaFormNovoLeilao
    {
        private IWebDriver _driver;

        public AoNavegarParaFormNovoLeilao(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdmDeveMostrarTresCategorias()
        {
            //arrange
            var loginPO = new LoginPO(_driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(_driver);

            //act
            novoLeilaoPO.Visitar();

            //assert - testando se a página possui todas as categorias listadas no PO
            Assert.Equal(3, novoLeilaoPO.Categorias.Count());
        }
    }
}
