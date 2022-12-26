using System;
using OpenQA.Selenium;

namespace _05_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class RegistroPO
    {
        private IWebDriver _driver;
        private By _byFormRegistro;
        private By _byInputNome;
        private By _byInputEmail;
        private By _byInputSenha;
        private By _byInputConfirmSenha;
        private By _byBotaoRegistro;
        private By _byEmailErroNome;

        public string EmailMensagemErro => _driver.FindElement(_byEmailErroNome).Text;

        public RegistroPO(IWebDriver driver)
        {
            _driver = driver;
            _byFormRegistro = By.TagName("form");
            _byInputNome = By.Id("Nome");
            _byInputEmail = By.Id("Email");
            _byInputSenha = By.Id("Password");
            _byInputConfirmSenha = By.Id("ConfirmPassword");
            _byBotaoRegistro = By.Id("btnRegistro");
            _byEmailErroNome = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
        }

        public void Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000");
        }

        public void SubmeteFormulatio()
        {
            _driver.FindElement(_byBotaoRegistro).Click();
        }
        public void PreencheFormulario(string nome, string email, string senha, string confirmSenha)
        {
            _driver.FindElement(_byInputNome).SendKeys(nome);
            _driver.FindElement(_byInputEmail).SendKeys(email);
            _driver.FindElement(_byInputSenha).SendKeys(senha);
            _driver.FindElement(_byInputConfirmSenha).SendKeys(confirmSenha);
        }
    }
}
