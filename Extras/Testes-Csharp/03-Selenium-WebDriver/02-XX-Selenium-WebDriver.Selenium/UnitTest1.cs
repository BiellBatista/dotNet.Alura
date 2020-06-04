using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit;

namespace _02_XX_Selenium_WebDriver.Selenium
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            // act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // assert
            Assert.Contains("Leilões", driver.Title);
        }
    }
}
