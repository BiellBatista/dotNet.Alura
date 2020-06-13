using _05_XX_Selenium_WebDriver.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace _05_XX_Selenium_WebDriver.Selenium.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup
        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
            // o selenium irá procurar um elemento a cada 10 segundos
            // estou alterando o Wait padrão do selenium (implicito)
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        //TearDown
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
