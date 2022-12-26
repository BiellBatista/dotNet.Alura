using System;
using OpenQA.Selenium;
using Xunit;
using _06_XX_Selenium_WebDriver.Selenium.PageObjects;
using _06_XX_Selenium_WebDriver.Selenium.Fixtures;

namespace _06_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoCriarLeilao
    {
        private IWebDriver driver;

        public AoCriarLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeilao()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencheFormulario(
                "Leilão de Coleção 1",
                "Nullam aliquet condimentum elit vitae volutpat. Vivamus ut nisi venenatis, facilisis odio eget, lobortis tortor. Cras mattis sit amet dolor id bibendum. Nulla turpis justo, porttitor eget leo vel, dictum tempor diam. Sed dui arcu, feugiat nec placerat ac, suscipit a mi. Etiam eget risus et tellus placerat tincidunt at ut lorem.",
                "Item de Colecionador",
                4000,
                "c:\\imagens\\colecao1.jpg",
                DateTime.Now.AddDays(20),
                DateTime.Now.AddDays(40)
            );

            //act
            novoLeilaoPO.SubmeteFormulario();

            //assert
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
