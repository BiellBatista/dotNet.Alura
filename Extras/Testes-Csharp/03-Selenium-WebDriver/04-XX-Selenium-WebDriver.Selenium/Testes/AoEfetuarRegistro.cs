using _04_XX_Selenium_WebDriver.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace _04_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver _driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arrange - dado chrome aberto na página inicial do sistema
            //dados de registros válidos
            _driver.Navigate().GoToUrl("http://localhost:5000");

            var inputNome = _driver.FindElement(By.Id("Nome"));
            var inputEmail = _driver.FindElement(By.Id("Email"));
            var inputSenha = _driver.FindElement(By.Id("Password"));
            var inputConfirmSenha = _driver.FindElement(By.Id("ConfirmPassword"));
            var botaoRegistro = _driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys("Gabriel Batista");
            inputEmail.SendKeys("gabriel.texteis@gmail.com");
            inputSenha.SendKeys("123");
            inputConfirmSenha.SendKeys("123");

            //act - efetuo o registro
            botaoRegistro.Click();

            //assert - devo ser redirecionado par auma página de agradecimento
            Assert.Contains("Obrigado", _driver.PageSource);
        }

        [Theory]
        [InlineData("", "gabriel.texteis@gmail.com", "123", "123")]
        [InlineData("Gabriel Batista", "gabriel", "123", "123")]
        [InlineData("Gabriel Batista", "gabriel.texteis@gmail.com", "123", "456")]
        [InlineData("Gabriel Batista", "gabriel.texteis@gmail.com", "123", "")]
        public void DadoInfoInvalidasDeveContinuarNaHome(
            string nome,
            string email,
            string senha,
            string confirmSenha)
        {
            //arrange - dado chrome aberto na página inicial do sistema
            //dados de registros válidos
            _driver.Navigate().GoToUrl("http://localhost:5000");

            var inputNome = _driver.FindElement(By.Id("Nome"));
            var inputEmail = _driver.FindElement(By.Id("Email"));
            var inputSenha = _driver.FindElement(By.Id("Password"));
            var inputConfirmSenha = _driver.FindElement(By.Id("ConfirmPassword"));
            var botaoRegistro = _driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(senha);
            inputConfirmSenha.SendKeys(confirmSenha);

            //act - efetuo o registro
            botaoRegistro.Click();

            //assert - devo ser redirecionado par auma página de agradecimento
            Assert.Contains("section-registro", _driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange - dado chrome aberto na página inicial do sistema
            _driver.Navigate().GoToUrl("http://localhost:5000");

            var botaoRegistro = _driver.FindElement(By.Id("btnRegistro"));

            //assert
            botaoRegistro.Click();

            //act
            IWebElement elemento = _driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
            Assert.Equal("The Nome field is required.", elemento.Text);
        }

        [Fact]
        public void DadoEmailInvalidoEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange - dado chrome aberto na página inicial do sistema
            _driver.Navigate().GoToUrl("http://localhost:5000");

            var inputEmail = _driver.FindElement(By.Id("Email"));
            var botaoRegistro = _driver.FindElement(By.Id("btnRegistro"));

            inputEmail.SendKeys("gabriel");

            //assert
            botaoRegistro.Click();

            //act
            IWebElement elemento = _driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Email]"));
            Assert.Equal("Please enter a valid email address.", elemento.Text);
        }
    }
}
