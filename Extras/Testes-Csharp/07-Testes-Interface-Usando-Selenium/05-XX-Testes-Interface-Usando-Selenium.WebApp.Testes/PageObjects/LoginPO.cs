using OpenQA.Selenium;

namespace _05_XX_Testes_Interface_Usando_Selenium.WebApp.Testes.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;
        private By campoEmail;
        private By campoSenha;
        private By btnLogar;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            campoEmail = By.Id("Email");
            campoSenha = By.Id("Senha");
            btnLogar = By.Id("btn-logar");
        }

        public void Navegar(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void PreencherCampos(string email, string senha)
        {
            driver.FindElement(campoSenha).SendKeys(senha);
            driver.FindElement(campoEmail).SendKeys(email);
        }

        public void Logar()
        {
            driver.FindElement(btnLogar).Click();
        }
    }
}