using _02_XX_Selenium_WebDriver.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace _02_XX_Selenium_WebDriver.Selenium
{
    public class AoNavegarParaHome
    {
        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            // arrange
            IWebDriver driver = new ChromeDriver(TestHelper.PastaDoExecutavel);

            // act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // assert
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            // arrange
            IWebDriver driver = new ChromeDriver(TestHelper.PastaDoExecutavel);

            // act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
