using OpenQA.Selenium;
using System;

namespace _02_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class NovoLeilaoPO
    {
        private IWebDriver _driver;
        private By _byInputTitulo;
        private By _byInputDescricao;
        private By _byInputCategoria;
        private By _byInputValorInicial;
        private By _byInputImagem;
        private By _byInputInicioPregao;
        private By _byInputTerminoPregao;

        public NovoLeilaoPO(IWebDriver driver)
        {
            _driver = driver;
            _byInputTitulo = By.Id("Titulo");
            _byInputDescricao = By.Id("Descricao");
            _byInputCategoria = By.Id("Categoria");
            _byInputValorInicial = By.Id("ValorInicial");
            _byInputImagem = By.Id("Imagem");
            _byInputInicioPregao = By.Id("InicioPregao");
            _byInputTerminoPregao = By.Id("TerminoPregao");
        }

        public void Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencheFormulario(
            string titulo,
            string descricao,
            string categoria,
            double valor,
            string imagem,
            DateTime inicio,
            DateTime termino)
        {
            _driver.FindElement(_byInputTitulo).SendKeys(titulo);
            _driver.FindElement(_byInputDescricao).SendKeys(descricao);
            _driver.FindElement(_byInputCategoria).SendKeys(categoria);
            _driver.FindElement(_byInputValorInicial).SendKeys(valor.ToString());
            _driver.FindElement(_byInputImagem).SendKeys(imagem);
            _driver.FindElement(_byInputInicioPregao).SendKeys(inicio.ToString());
            _driver.FindElement(_byInputTerminoPregao).SendKeys(termino.ToString());
        }
    }
}
