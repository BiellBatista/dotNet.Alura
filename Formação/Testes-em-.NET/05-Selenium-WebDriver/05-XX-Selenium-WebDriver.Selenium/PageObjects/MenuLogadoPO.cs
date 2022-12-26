using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace _05_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class MenuLogadoPO
    {
        private IWebDriver _driver;
        private By _byLogoutLink;
        private By _byMeuPerfilLink;

        public MenuLogadoPO(IWebDriver driver)
        {
            _driver = driver;
            _byLogoutLink = By.Id("logout");
            _byMeuPerfilLink = By.Id("meu-perfil");
        }

        public void EfetuarLogout()
        {
            var linkMeuPerfil = _driver.FindElement(_byMeuPerfilLink);
            var linkLogout = _driver.FindElement(_byLogoutLink);

            IAction acaoLogout = new Actions(_driver)
                //mover para o elemento meu-perfil
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
