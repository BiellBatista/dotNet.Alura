using _05_XX_Selenium_WebDriver.Selenium.Fixtures;
using _05_XX_Selenium_WebDriver.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace _05_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver _driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            //arrange
            var loginPO = new LoginPO(_driver);

            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");

            //act
            loginPO.SubmeteFormulario();

            //assert
            Assert.Contains("Dashboard", _driver.Title);
        }

        [Fact]
        public void DadoCrendenciasInvalidasDeveContinuarLogin()
        {
            //arrange
            var loginPO = new LoginPO(_driver);

            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "1234");

            //act
            loginPO.SubmeteFormulario();

            //assert
            Assert.Contains("Login", _driver.PageSource);
        }
    }
}
