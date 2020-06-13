using OpenQA.Selenium;
using Xunit;
using _04_XX_Selenium_WebDriver.Selenium.PageObjects;
using _04_XX_Selenium_WebDriver.Selenium.Fixtures;
using OpenQA.Selenium.Support.UI;
using System;

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
            // falando para o selenium esperar oito segundos
            // criando um wait explicito
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            bool iguais = wait.Until(drv => detalhePO.LanceAtual == 300);

            Assert.True(iguais);
        }
    }
}
