using _02_03_XX_Inversao_Dependencias.WebApp.Dados;
using _02_03_XX_Inversao_Dependencias.WebApp.Dados.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace _02_03_XX_Inversao_Dependencias.WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //falando para o .net Core que onde estiver ILeilaoDao (construtor), será instanciado o LeiaoDaoComEFCore
            services.AddTransient<ILeilaoDao, LeilaoDaoComEFCore>();
            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePagesWithRedirects("/Home/StatusCode/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
