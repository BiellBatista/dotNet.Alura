using _04_XX_Selenium_WebDriver.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace _04_XX_Selenium_WebDriver.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arrange - dado chrome aberto na página inicial do sistema
            //dados de registros válidos
            driver.Navigate().GoToUrl("http://localhost:5000");

            var inputNome = driver.FindElement(By.Id("Nome"));
            var inputEmail = driver.FindElement(By.Id("Email"));
            var inputSenha = driver.FindElement(By.Id("Password"));
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys("Gabriel Batista");
            inputEmail.SendKeys("gabriel.texteis@gmail.com");
            inputSenha.SendKeys("123");
            inputConfirmSenha.SendKeys("123");

            //act - efetuo o registro
            botaoRegistro.Click();

            //assert - devo ser redirecionado par auma página de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
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
            driver.Navigate().GoToUrl("http://localhost:5000");

            var inputNome = driver.FindElement(By.Id("Nome"));
            var inputEmail = driver.FindElement(By.Id("Email"));
            var inputSenha = driver.FindElement(By.Id("Password"));
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(senha);
            inputConfirmSenha.SendKeys(confirmSenha);

            //act - efetuo o registro
            botaoRegistro.Click();

            //assert - devo ser redirecionado par auma página de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
        }
    }
}
