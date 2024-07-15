using _10_05_XX_Fluxo_Completo.Dados;
using Microsoft.EntityFrameworkCore;

namespace _10_05_XX_Fluxo_Completo.API.Service;

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