using _10_01_XX_Pipeline_Testes_GitHub_Actions.Dados;
using Microsoft.EntityFrameworkCore;

namespace _10_01_XX_Pipeline_Testes_GitHub_Actions.API.Service;

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