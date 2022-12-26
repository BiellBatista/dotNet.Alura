using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace _03_XX_Selenium_WebDriver.Selenium.Helpers
{
    public class SelectMaterialize
    {
        private IWebDriver _driver;
        private IWebElement _selectWrapper;
        private IEnumerable<IWebElement> _opcoes;

        public SelectMaterialize(IWebDriver driver, By locatorSelectWrapper)
        {
            _driver = driver;
            _selectWrapper = _driver.FindElement(locatorSelectWrapper);
            _opcoes = _selectWrapper.FindElements(By.CssSelector("li>span"));
        }

        public IEnumerable<IWebElement> Options => _opcoes;

        private void OpenWrapper()
        {
            _selectWrapper.Click();
        }

        private void LoseFocus()
        {
            _selectWrapper
                .FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);
        }

        public void DeselectAll()
        {
            OpenWrapper();
            _opcoes.ToList().ForEach(o => o.Click());
            LoseFocus();
        }

        public void SelectByText(string option)
        {
            OpenWrapper();
            _opcoes
                .Where(o => o.Text.Contains(option))
                .ToList()
                .ForEach(o => o.Click());
            LoseFocus();
        }
    }
}
