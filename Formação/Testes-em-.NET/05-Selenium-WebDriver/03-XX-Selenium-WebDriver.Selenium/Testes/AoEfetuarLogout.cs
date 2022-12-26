using _03_XX_Selenium_WebDriver.Selenium.Fixtures;
using _03_XX_Selenium_WebDriver.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace _03_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogout
    {
        private IWebDriver _driver;

        public AoEfetuarLogout(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada()
        {
            //arrange
            var loginPO = new LoginPO(_driver);

            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            var dashboardPO = new DashboardInteressadaPO(_driver);

            //act - efetuar logout
            dashboardPO.EfetuarLogout();

            //assert
            Assert.Contains("Próximos Leilões", _driver.PageSource);
        }
    }
}
