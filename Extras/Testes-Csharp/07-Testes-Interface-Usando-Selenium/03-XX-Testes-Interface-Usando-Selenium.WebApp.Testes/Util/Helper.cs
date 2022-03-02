using System.IO;
using System.Reflection;

namespace _03_XX_Testes_Interface_Usando_Selenium.WebApp.Testes.Util
{
    public static class Helper
    {
        public static string CaminhoDriverNavegador() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}