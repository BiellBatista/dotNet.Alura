using _09_03_XX_Testes_Endpoints.HTTPS.Dados;
using Microsoft.EntityFrameworkCore;

namespace _09_03_XX_Testes_Endpoints.HTTPS.API.Service;

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