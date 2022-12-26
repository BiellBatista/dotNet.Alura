using Xunit;
using OpenQA.Selenium;
using _04_XX_Selenium_WebDriver.Selenium.Fixtures;
using _04_XX_Selenium_WebDriver.Selenium.PageObjects;

namespace _04_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogout
    {
        private IWebDriver driver;

        public AoEfetuarLogout(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            var dashboardPO = new DashboardInteressadaPO(driver);

            //act - efetuar logout
            dashboardPO.EfetuarLogout();

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);

        }
    }
}
