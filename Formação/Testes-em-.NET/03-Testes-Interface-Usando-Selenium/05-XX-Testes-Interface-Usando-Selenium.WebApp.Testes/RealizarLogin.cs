﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using Xunit;

namespace _05_XX_Testes_Interface_Usando_Selenium.WebApp.Testes
{
    public class RealizarLogin : IDisposable
    {
        public IWebDriver driver { get; private set; }
        public IDictionary<string, object> vars { get; private set; }
        public IJavaScriptExecutor js { get; private set; }

        public RealizarLogin()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void ExecutandoLoginWebApp()
        {
            // Test name: ExecutandoLoginWebApp
            // Step # | name | target | value
            // 1 | open | / |
            driver.Navigate().GoToUrl("https://localhost:44309/");
            // 2 | setWindowSize | 1309x712 |
            driver.Manage().Window.Size = new System.Drawing.Size(1309, 712);
            // 3 | assertElementPresent | linkText=Home |
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.LinkText("Home"));
                Assert.True(elements.Count > 0);
            }
            // 4 | assertElementPresent | linkText=ByteBank-WebApp |
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.LinkText("ByteBank-WebApp"));
                Assert.True(elements.Count > 0);
            }
            // 5 | click | linkText=Login |
            driver.FindElement(By.LinkText("Login")).Click();
            // 6 | click | id=Email |
            driver.FindElement(By.Id("Email")).Click();
            // 7 | type | id=Email | andre@email.com
            driver.FindElement(By.Id("Email")).SendKeys("andre@email.com");
            // 8 | click | id=Senha |
            driver.FindElement(By.Id("Senha")).Click();
            // 9 | type | id=Senha | senha01
            driver.FindElement(By.Id("Senha")).SendKeys("senha01");
            // 10 | click | id=btn-logar |
            driver.FindElement(By.Id("btn-logar")).Click();
            // 11 | assertElementPresent | id=agencia |
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Id("agencia"));
                Assert.True(elements.Count > 0);
            }
            // 12 | verifyElementPresent | css=.btn |
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector(".btn"));
                Assert.True(elements.Count > 0);
            }
            // 13 | click | css=.btn |
            driver.FindElement(By.CssSelector(".btn")).Click();
        }
    }
}