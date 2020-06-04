using _02_XX_Selenium_WebDriver.Selenium.Helpers;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace _02_XX_Selenium_WebDriver.Selenium
{
    public class AoNavegarParaHome : IDisposable
    {
        private ChromeDriver driver;

        // Setup (inicializando os recursos)
        public AoNavegarParaHome()
        {
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
        }

        //TearDown (liberar os recursos que foram inicializados)
        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            // arrange

            // act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // assert
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            // arrange

            // act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
