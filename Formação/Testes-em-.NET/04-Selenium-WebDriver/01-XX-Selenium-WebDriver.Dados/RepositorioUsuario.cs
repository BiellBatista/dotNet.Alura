using _01_XX_Selenium_WebDriver.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _01_XX_Selenium_WebDriver.Dados
{
    public class RepositorioUsuario : RepositorioBase<Usuario>
    {
        public RepositorioUsuario(LeiloesContext ctx) : base(ctx)
        {

        }

        public override Usuario BuscarPorId(int id)
        {
            return _ctx.Usuarios
                .Include(u => u.Interessada)
                .FirstOrDefault(u => u.Id == id);
        }

    }
}
