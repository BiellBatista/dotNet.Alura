using _02_01_XX_Qualidade_Software.WebApp.Seeding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace _02_01_XX_Qualidade_Software.WebApp
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
