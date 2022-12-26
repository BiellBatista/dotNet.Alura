using Xunit;
using OpenQA.Selenium;
using _06_XX_Selenium_WebDriver.Selenium.Fixtures;
using _06_XX_Selenium_WebDriver.Selenium.PageObjects;

namespace _06_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogout
    {
        private IWebDriver _driver;

        public AoEfetuarLogout(TestFixture fixture) => _driver = fixture.Driver;

        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada()
        {
            //arrange
            new LoginPO(_driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("123")
                .EfetuarLogin();

            var dashboardPO = new DashboardInteressadaPO(_driver);

            //act - efetuar logout
            dashboardPO.Menu.EfetuarLogout();

            //assert
            Assert.Contains("Próximos Leilões", _driver.PageSource);
        }
    }
}
