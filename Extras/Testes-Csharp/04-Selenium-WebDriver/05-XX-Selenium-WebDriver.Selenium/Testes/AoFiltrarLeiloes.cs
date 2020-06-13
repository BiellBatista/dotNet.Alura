using _05_XX_Selenium_WebDriver.Selenium.Fixtures;
using _05_XX_Selenium_WebDriver.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace _05_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        private IWebDriver driver;

        public AoFiltrarLeiloes(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveMostrarPainelResultado()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            var dashboardInteressadaPO = new DashboardInteressadaPO(driver);

            //act
            dashboardInteressadaPO.PesquisarLeiloes(
                new List<string> { "Arte", "Coleções" },
                "",
                true);

            //assert
            Assert.Contains("Resultado da pesquisa", driver.PageSource);

        }
    }
}
