using _05_XX_Selenium_WebDriver.Selenium.Helpers;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace _05_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class FiltroLeiloesPO
    {
        private IWebDriver _driver;
        private By _bySelectCategorias;
        private By _byInputTermo;
        private By _byInputAndamento;
        private By _byBotaoPesquisar;

        public FiltroLeiloesPO(IWebDriver driver)
        {
            _driver = driver;
            _bySelectCategorias = By.ClassName("select-wrapper");
            _byInputTermo = By.Id("termo");
            _byInputAndamento = By.ClassName("switch");
            _byBotaoPesquisar = By.CssSelector("form>button.btn");
        }

        public void PesquisarLeiloes(
            List<string> categorias,
            string termo,
            bool emAndamento)
        {
            var select = new SelectMaterialize(_driver, _bySelectCategorias);
            select.DeselectAll();
            categorias.ForEach(categ =>
            {
                select.SelectByText(categ);
            });
            _driver.FindElement(_byInputTermo).SendKeys(termo);
            if (emAndamento)
            {
                _driver.FindElement(_byInputAndamento).Click();
            }
            _driver.FindElement(_byBotaoPesquisar).Click();
        }
    }
}
