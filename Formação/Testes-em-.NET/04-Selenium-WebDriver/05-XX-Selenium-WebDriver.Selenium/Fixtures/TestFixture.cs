using _05_XX_Selenium_WebDriver.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace _05_XX_Selenium_WebDriver.Selenium.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; set; }

        // Setup (inicializando os recursos)
        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
        }

        //TearDown (liberar os recursos que foram inicializados)
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
