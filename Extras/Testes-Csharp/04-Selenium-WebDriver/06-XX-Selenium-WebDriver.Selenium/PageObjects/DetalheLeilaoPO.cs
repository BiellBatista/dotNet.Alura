using OpenQA.Selenium;

namespace _06_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class DetalheLeilaoPO
    {
        private IWebDriver _driver;
        private By _byInputValor;
        private By _byLanceAtual;
        private By _byBotaoOferta;

        public double LanceAtual
        {
            get
            {
                var valorTexto = _driver.FindElement(_byLanceAtual).Text;
                return double.Parse(valorTexto, System.Globalization.NumberStyles.Currency);
            }
        }

        public DetalheLeilaoPO(IWebDriver driver)
        {
            _driver = driver;
            _byInputValor = By.Id("Valor");
            _byBotaoOferta = By.Id("btnDarLance");
            _byLanceAtual = By.Id("lanceAtual");
        }

        public void Visitar(int idLeilao)
        {
            _driver.Navigate().GoToUrl($"http://localhost:5000/Home/Detalhes/{idLeilao}");
        }

        public void OfertarLance(double valor)
        {
            _driver.FindElement(_byInputValor).SendKeys(valor.ToString());
            _driver.FindElement(_byBotaoOferta).Click();
        }
    }
}
