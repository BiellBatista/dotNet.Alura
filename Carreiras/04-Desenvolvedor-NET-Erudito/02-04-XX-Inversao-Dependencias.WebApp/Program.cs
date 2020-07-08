using _02_04_XX_Inversao_Dependencias.WebApp.Seeding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace _02_04_XX_Inversao_Dependencias.WebApp
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
