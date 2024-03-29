﻿using OpenQA.Selenium;

namespace _06_XX_Selenium_WebDriver.Selenium.PageObjects
{
    public class MenuNaoLogadoPO
    {
        private IWebDriver _driver;
        private By _byMenuMobile;

        public bool MenuMobileVisivel
        {
            get
            {
                var elemento = _driver.FindElement(_byMenuMobile);

                return elemento.Displayed;
            }
        }

        public MenuNaoLogadoPO(IWebDriver driver)
        {
            _driver = driver;
            _byMenuMobile = By.ClassName("sidenav-trigger");
        }
    }
}
