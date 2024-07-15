using _10_04_XX_Criando_Pipeline_Azure_Devops.Dados;
using Microsoft.EntityFrameworkCore;

namespace _10_04_XX_Criando_Pipeline_Azure_Devops.API.Service;

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