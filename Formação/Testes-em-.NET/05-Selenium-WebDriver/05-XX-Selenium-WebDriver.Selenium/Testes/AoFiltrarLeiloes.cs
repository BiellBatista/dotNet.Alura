using _05_XX_Selenium_WebDriver.Selenium.Fixtures;
using _05_XX_Selenium_WebDriver.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using Xunit;

namespace _05_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        private IWebDriver _driver;

        public AoFiltrarLeiloes(TestFixture fixture) => _driver = fixture.Driver;

        [Fact]
        public void DadoLoginInteressadaDeveMostrarPainelResultado()
        {
            //arrange
            new LoginPO(_driver).EfetuarLoginComCredenciais("fulano@example.org", "123");

            var dashboardInteressadaPO = new DashboardInteressadaPO(_driver);

            //act
            dashboardInteressadaPO.Filtro.PesquisarLeiloes(
                new List<string> { "Arte", "Coleções" },
                "",
                true);

            //assert
            Assert.Contains("Resultado da pesquisa", _driver.PageSource);
        }
    }
}
