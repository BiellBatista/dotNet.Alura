using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace _03_XX_Selenium_WebDriver.Selenium.Helpers
{
    public static class TestHelper
    {
        public static string PastaDoExecutavel => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
