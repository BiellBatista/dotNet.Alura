using OpenQA.Selenium;

namespace _06_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class MenuNaoLogadoPO
    {
        private IWebDriver _driver;

        public bool MenuMobileVisivel { get; set; }

        public MenuNaoLogadoPO(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
