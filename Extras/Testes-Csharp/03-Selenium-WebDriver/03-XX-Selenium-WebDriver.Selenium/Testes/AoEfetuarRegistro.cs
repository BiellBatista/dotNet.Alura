using _03_XX_Selenium_WebDriver.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace _03_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void Teste()
        {
            //arrange - dado chrome aberto na página inicial do sistema
            //dados de registros válidos
            driver.Navigate().GoToUrl("http://localhost:500");


            //act - efetuo o registro

            //assert - devo ser redirecionado par auma página de agradecimento
        }
    }
}
