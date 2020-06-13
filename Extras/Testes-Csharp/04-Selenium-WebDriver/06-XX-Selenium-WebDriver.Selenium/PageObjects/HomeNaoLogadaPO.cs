using OpenQA.Selenium;

namespace _06_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class HomeNaoLogadaPO
    {
        private IWebDriver _driver;

        public MenuNaoLogadoPO Menu { get; }

        public HomeNaoLogadaPO(IWebDriver driver)
        {
            _driver = driver;
            Menu = new MenuNaoLogadoPO(driver);
        }

        public void Visitar() => _driver.Navigate().GoToUrl("http://localhost:5000");
    }
}
