using OpenQA.Selenium;

namespace _05_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class LoginPO
    {
        private IWebDriver _driver;
        private By _byInputLogin;
        private By _byInputSenha;
        private By _byBtnLogin;

        public LoginPO(IWebDriver driver)
        {
            _driver = driver;
            _byInputLogin = By.Id("Login");
            _byInputSenha = By.Id("Password");
            _byBtnLogin = By.Id("btnLogin");
        }

        public void Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
        }

        public void PreencheFormulario(string login, string senha)
        {
            _driver.FindElement(_byInputLogin).SendKeys(login);
            _driver.FindElement(_byInputSenha).SendKeys(senha);
        }

        public void SubmeteFormulario()
        {
            _driver.FindElement(_byBtnLogin).Submit();
        }
    }
}
