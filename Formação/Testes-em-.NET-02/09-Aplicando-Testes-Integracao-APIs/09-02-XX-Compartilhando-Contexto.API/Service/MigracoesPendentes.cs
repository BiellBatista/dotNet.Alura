using _09_02_XX_Compartilhando_Contexto.Dados;
using Microsoft.EntityFrameworkCore;

namespace _09_02_XX_Compartilhando_Contexto.API.Service;

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