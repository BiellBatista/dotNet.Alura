using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_XX_Selenium_WebDriver.Selenium.PageObjects
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
        private By _byBotaoSalvar;

        public IEnumerable<string> Categorias
        {
            get
            {
                var elementoCategoria = new SelectElement(_driver.FindElement(_byInputCategoria));
                return elementoCategoria
                    .Options
                    .Where(o => o.Enabled)
                    .Select(o => o.Text);
            }
        }

        public NovoLeilaoPO(IWebDriver driver)
        {
            _driver = driver;
            _byInputTitulo = By.Id("Titulo");
            _byInputDescricao = By.Id("Descricao");
            _byInputCategoria = By.Id("Categoria");
            _byInputValorInicial = By.Id("ValorInicial");
            _byInputImagem = By.Id("ArquivoImagem");
            _byInputInicioPregao = By.Id("InicioPregao");
            _byInputTerminoPregao = By.Id("TerminoPregao");
            _byBotaoSalvar = By.CssSelector("button[type=submit]");
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
            //_driver.FindElement(_byInputCategoria).SendKeys(categoria);
            _driver.FindElement(_byInputValorInicial).SendKeys(valor.ToString());
            _driver.FindElement(_byInputImagem).SendKeys(imagem);
            _driver.FindElement(_byInputInicioPregao).SendKeys(inicio.ToString("dd/MM/yyyy"));
            _driver.FindElement(_byInputTerminoPregao).SendKeys(termino.ToString("dd/MM/yyyy"));
        }

        public void SubmeteFormulario()
        {
            _driver.FindElement(_byBotaoSalvar).Click();
        }
    }
}
