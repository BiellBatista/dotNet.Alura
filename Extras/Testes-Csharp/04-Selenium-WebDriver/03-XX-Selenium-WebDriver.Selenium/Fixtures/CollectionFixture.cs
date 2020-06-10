using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace _03_XX_Selenium_WebDriver.Selenium.Fixtures
{
    [CollectionDefinition("Chrome Driver")]
    public class CollectionFixture : ICollectionFixture<TestFixture>
    {
    }
}
