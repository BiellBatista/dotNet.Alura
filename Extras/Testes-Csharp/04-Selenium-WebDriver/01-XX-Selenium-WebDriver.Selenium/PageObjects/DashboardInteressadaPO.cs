using OpenQA.Selenium;

namespace _01_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver _driver;
        private By _byLogoutLink;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            _driver = driver;
            _byLogoutLink = By.Id("logout");
        }

        public void EfetuarLogout()
        {
            _driver.FindElement(_byLogoutLink).Click();
        }
    }
}
