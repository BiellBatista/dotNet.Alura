using _04_02_XX_CasaDoCodigo.Areas.Identity.Data;
using _04_02_XX_CasaDoCodigo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//este atributo assembly faz com que este arquivo startup seja paralelo ao original
[assembly: HostingStartup(typeof(_04_02_XX_CasaDoCodigo.Areas.Identity.IdentityHostingStartup))]
namespace _04_02_XX_CasaDoCodigo.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AppIdentityContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("AppIdentityContextConnection")));

                services.AddDefaultIdentity<AppIdentityUser>()
                    .AddEntityFrameworkStores<AppIdentityContext>();
            });
        }
    }
}