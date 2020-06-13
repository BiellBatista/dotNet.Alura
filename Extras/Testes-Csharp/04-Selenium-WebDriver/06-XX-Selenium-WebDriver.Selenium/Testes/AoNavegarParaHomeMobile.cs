﻿using _06_XX_Selenium_WebDriver.Selenium.Helpers;
using _06_XX_Selenium_WebDriver.Selenium.PageObjects;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace _06_XX_Selenium_WebDriver.Selenium.Testes
{
    public class AoNavegarParaHomeMobile : IDisposable
    {
        private ChromeDriver _driver;

        public AoNavegarParaHomeMobile()
        {
            //configurando a visualização para mobile
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 400;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizado";

            //ativando a visão mobile
            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);

            _driver = new ChromeDriver(TestHelper.PastaDoExecutavel, options);
        }

        public void Dispose() => _driver.Quit();

        [Fact]
        public void DadaLargura400DeveMostrarMenuMobile()
        {
            //arrange
            var homePO = new HomeNaoLogadaPO(_driver);

            //act
            homePO.Visitar();

            //assert
            Assert.True(homePO.Menu.MenuMobileVisivel);
        }
    }
}
