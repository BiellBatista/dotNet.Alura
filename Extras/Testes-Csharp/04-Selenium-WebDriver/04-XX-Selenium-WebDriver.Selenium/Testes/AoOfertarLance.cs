using OpenQA.Selenium;
using Xunit;
using _04_XX_Selenium_WebDriver.Selenium.PageObjects;
using _04_XX_Selenium_WebDriver.Selenium.Fixtures;

namespace _04_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoOfertarLance
    {
        private IWebDriver _driver;

        public AoOfertarLance(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveAtualizarLanceAtual()
        {
            //arrange
            var loginPO = new LoginPO(_driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fluano@example.org", "123");
            loginPO.SubmeteFormulario();

            var detalhePO = new DetalheLeilaoPO(_driver);
            detalhePO.Visitar(1);

            //act
            detalhePO.OfertarLance(300);

            //assert
            Assert.Equal(300, detalhePO.LanceAtual);
        }
    }
}
