using _02_02_XX_Responsabilidade_Unica.WebApp.Seeding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace _02_02_XX_Responsabilidade_Unica.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DatabaseGenerator.Seed();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
