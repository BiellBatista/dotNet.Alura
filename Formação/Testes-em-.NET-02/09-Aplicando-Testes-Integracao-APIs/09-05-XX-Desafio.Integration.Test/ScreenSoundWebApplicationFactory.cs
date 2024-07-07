using _09_05_XX_Desafio.Dados.Banco;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace _09_05_XX_Desafio.Integration.Test
{
    public class ScreenSoundWebApplicationFactory : WebApplicationFactory<Program>
    {
        public ScreenSoundContext Context { get; }

        private IServiceScope scope;

        public ScreenSoundWebApplicationFactory()
        {
            scope = Services.CreateScope();
            Context = scope.ServiceProvider.GetRequiredService<ScreenSoundContext>();
        }
    }
}