﻿using System.IO;
using System.Reflection;

namespace _03_XX_Selenium_WebDriver.Selenium.Helpers
{
    public static class TestHelper
    {
        public static string PastaDoExecutavel => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
