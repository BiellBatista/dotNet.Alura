using OpenQA.Selenium;

namespace _06_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class LoginPO
    {
        private IWebDriver _driver;
        private By _byInputLogin;
        private By _byInputSenha;
        private By _byBotaoLogin;

        public LoginPO(IWebDriver driver)
        {
            _driver = driver;
            _byInputLogin = By.Id("Login");
            _byInputSenha = By.Id("Password");
            _byBotaoLogin = By.Id("btnLogin");
        }

        public LoginPO Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");

            return this;
        }

        // essa assinatura de método é usada para Linguagem Fluente, muito utilizada no LinQ e no EF
        public LoginPO PreencheFormulario(string login, string senha) => InformarEmail(login).InformarSenha(senha);

        public LoginPO InformarEmail(string login)
        {
            _driver.FindElement(_byInputLogin).SendKeys(login);

            return this;
        }

        public LoginPO InformarSenha(string senha)
        {
            _driver.FindElement(_byInputSenha).SendKeys(senha);

            return this;
        }

        public LoginPO EfetuarLogin() => SubmeteFormulario();

        public LoginPO SubmeteFormulario()
        {
            _driver.FindElement(_byBotaoLogin).Submit();

            return this;
        }

        public void EfetuarLoginComCredenciais(string login, string senha) => Visitar()
            .PreencheFormulario(login, senha)
            .SubmeteFormulario();
    }
}
