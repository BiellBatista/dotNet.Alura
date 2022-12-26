using _03_XX_Selenium_WebDriver.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Threading;

namespace _03_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver _driver;
        private By _byLogoutLink;
        private By _byMeuPerfilLink;
        private By _bySelectCategorias;
        private By _byInputTermo;
        private By _byInputAndamento;
        private By _byBotaoPesquisar;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            _driver = driver;
            _byLogoutLink = By.Id("logout");
            _byMeuPerfilLink = By.Id("meu-perfil");
            _bySelectCategorias = By.ClassName("select-wrapper");
            _byInputTermo = By.Id("termo");
            _byInputAndamento = By.ClassName("switch");
            _byBotaoPesquisar = By.CssSelector("form>button.btn");
        }

        public void PesquisarLeiloes(List<string> categorias, string termo, bool emAndamento)
        {
            var select = new SelectMaterialize(_driver, _bySelectCategorias);

            select.DeselectAll();
            categorias.ForEach(c => select.SelectByText(c));

            _driver.FindElement(_byInputTermo).SendKeys(termo);

            if (emAndamento)
            {
                _driver.FindElement(_byInputAndamento).Click();
            }

            _driver.FindElement(_byBotaoPesquisar).Click();
        }

        /**
         * Quando eu não consigo interagir com um elemento, porque ele está invisivel. Devo simular a interação
         * que o usuário irá realizar. Este método simula tal ação
         */
        public void EfetuarLogout()
        {
            // não é possível interagir com um elemento invisivel, devo simular as ações do usuário
            // _driver.FindElement(_byLogoutLink).Click(); //não funciona, porque não foi simulado as ações
            var linkLogout = _driver.FindElement(_byLogoutLink);
            var linkMeuPerfil = _driver.FindElement(_byMeuPerfilLink);

            //criando a ação
            IAction acaoLogout = new Actions(_driver)
            //mover para o elemento pai (meu-perfil)
                .MoveToElement(linkMeuPerfil)
            //mover para o link de logout
                .MoveToElement(linkLogout)
            //clicar no link de logout
                .Click()
                .Build();

            acaoLogout.Perform();
        }
    }
}
