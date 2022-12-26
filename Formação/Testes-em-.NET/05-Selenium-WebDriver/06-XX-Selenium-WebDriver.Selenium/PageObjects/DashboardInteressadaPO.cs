using OpenQA.Selenium;

namespace _06_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;

        public FiltroLeiloesPO Filtro { get; }
        public MenuLogadoPO Menu { get; }

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            Filtro = new FiltroLeiloesPO(driver);
            Menu = new MenuLogadoPO(driver);
        }
    }
}
