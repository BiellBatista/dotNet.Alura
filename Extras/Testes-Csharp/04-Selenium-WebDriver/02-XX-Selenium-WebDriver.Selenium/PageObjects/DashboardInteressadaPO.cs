using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace _02_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver _driver;
        private By _byLogoutLink;
        private By _byMeuPerfilLink;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            _driver = driver;
            _byLogoutLink = By.Id("logout");
            _byMeuPerfilLink = By.Id("meu-perfil");
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
