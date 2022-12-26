using _05_XX_Selenium_WebDriver.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _05_XX_Selenium_WebDriver.Dados
{
    public class RepositorioLeilao : RepositorioBase<Leilao>
    {
        public RepositorioLeilao(LeiloesContext context): base(context) { }

        public override Leilao BuscarPorId(int id)
        {
            return _ctx.Leiloes
                .Include(l => l.Lances)
                .Include(l => l.Seguidores)
                .FirstOrDefault(l => l.Id == id);
        }
    }
}
