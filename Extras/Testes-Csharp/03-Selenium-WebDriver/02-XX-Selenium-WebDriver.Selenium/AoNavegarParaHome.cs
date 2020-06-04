using _02_XX_Selenium_WebDriver.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace _02_XX_Selenium_WebDriver.Selenium
{
    public class AoNavegarParaHome : IClassFixture<TestFixture>
    {
        private IWebDriver _driver;

        // Setup (inicializando os recursos)
        /**
         * Marco esta classe com a interface ClassFixture e passo a classe que cuidará dos recursos
         * devo passar no construtor a classe que cuidará dos recursos
         */
        public AoNavegarParaHome(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            // arrange

            // act
            _driver.Navigate().GoToUrl("http://localhost:5000");

            // assert
            Assert.Contains("Leilões", _driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            // arrange

            // act
            _driver.Navigate().GoToUrl("http://localhost:5000");

            // assert
            Assert.Contains("Próximos Leilões", _driver.PageSource);
        }
    }
}
