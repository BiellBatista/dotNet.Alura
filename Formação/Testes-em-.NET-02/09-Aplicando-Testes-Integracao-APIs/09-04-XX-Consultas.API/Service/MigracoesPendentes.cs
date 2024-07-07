using _09_04_XX_Consultas.Dados;
using Microsoft.EntityFrameworkCore;

namespace _09_04_XX_Consultas.API.Service;

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