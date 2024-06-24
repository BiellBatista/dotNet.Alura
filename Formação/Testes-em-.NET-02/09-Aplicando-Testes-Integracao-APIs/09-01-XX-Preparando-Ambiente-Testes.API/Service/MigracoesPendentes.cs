using _09_01_XX_Preparando_Ambiente_Testes.Dados;
using Microsoft.EntityFrameworkCore;

namespace _09_01_XX_Preparando_Ambiente_Testes.API.Service;

public static class MigracoesPendentes
{
    public static void ExecuteMigration(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var serviceDb = serviceScope.ServiceProvider
                             .GetService<JornadaMilhasContext>();

            serviceDb!.Database.Migrate();
        }
    }
}