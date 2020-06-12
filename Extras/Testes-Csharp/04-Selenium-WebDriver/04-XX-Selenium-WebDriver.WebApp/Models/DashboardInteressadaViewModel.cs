using _04_XX_Selenium_WebDriver.Core;
using System.Collections.Generic;

namespace _04_XX_Selenium_WebDriver.WebApp.Models
{
    public class DashboardInteressadaViewModel
    {
        public IEnumerable<Lance> MinhasOfertas { get; set; }
        public IEnumerable<Leilao> LeiloesFavoritos { get; set; }
        public IEnumerable<Leilao> LeiloesPesquisados { get; set; }
    }
}
