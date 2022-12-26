using OpenQA.Selenium;
using System;
using Xunit;
using _03_XX_Selenium_WebDriver.Selenium.PageObjects;
using _03_XX_Selenium_WebDriver.Selenium.Fixtures;
using System.Threading;

namespace _03_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoCriarLeilao
    {
        private IWebDriver _driver;

        public AoCriarLeilao(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeialo()
        {
            //arrange
            var loginPO = new LoginPO(_driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(_driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencheFormulario(
                "Leilão de Coleção 1",
                "Descrição Teste",
                "Item de Colecionador",
                4000,
                "c:\\Users\\Gabriel Batista\\Downloads\\0123.png",
                DateTime.Now.AddDays(20),
                DateTime.Now.AddDays(40));

            //act
            novoLeilaoPO.SubmeteFormulario();

            //assert
            Assert.Contains("Leilões cadastrados no sistema", _driver.PageSource);
        }
    }
}
