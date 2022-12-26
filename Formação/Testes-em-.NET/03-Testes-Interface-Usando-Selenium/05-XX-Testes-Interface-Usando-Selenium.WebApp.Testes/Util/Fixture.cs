using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace _05_XX_Testes_Interface_Usando_Selenium.WebApp.Testes.Util
{
    public class Fixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public Fixture()
        {
            Driver = new ChromeDriver(Helper.CaminhoDriverNavegador());
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}