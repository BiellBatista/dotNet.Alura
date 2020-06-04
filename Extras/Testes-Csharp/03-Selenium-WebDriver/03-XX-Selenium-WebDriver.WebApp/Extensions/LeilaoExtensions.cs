using _03_XX_Selenium_WebDriver.Core;
using _03_XX_Selenium_WebDriver.WebApp.Models;

namespace _03_XX_Selenium_WebDriver.WebApp.Extensions
{
    public static class LeilaoExtensions
    {
        public static LeilaoViewModel ToViewModel(this Leilao leilao)
        {
            return new LeilaoViewModel
            {
                Id = leilao.Id,
                Titulo = leilao.Titulo,
                Descricao = leilao.Descricao,
                Categoria = leilao.Categoria,
                Imagem = leilao.Imagem,
                InicioPregao = leilao.InicioPregao,
                TerminoPregao = leilao.TerminoPregao,
                ValorInicial = leilao.ValorInicial,
                Estado = leilao.Estado,
                Lances = leilao.Lances
            };
        }

        public static Leilao ToModel(this LeilaoViewModel leilao)
        {
            return new Leilao(leilao.Titulo, null)
            {
                Id = leilao.Id,
                Titulo = leilao.Titulo,
                Descricao = leilao.Descricao,
                Categoria = leilao.Categoria,
                Imagem = leilao.Imagem,
                InicioPregao = leilao.InicioPregao,
                TerminoPregao = leilao.TerminoPregao,
                ValorInicial = leilao.ValorInicial
            };
        }
    }
}
