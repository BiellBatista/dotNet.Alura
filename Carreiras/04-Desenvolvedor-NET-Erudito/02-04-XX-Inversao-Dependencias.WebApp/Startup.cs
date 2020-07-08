using _02_04_XX_Inversao_Dependencias.WebApp.Dados;
using _02_04_XX_Inversao_Dependencias.WebApp.Dados.EfCore;
using _02_04_XX_Inversao_Dependencias.WebApp.Services;
using _02_04_XX_Inversao_Dependencias.WebApp.Services.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace _02_04_XX_Inversao_Dependencias.WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICategoriaDao, CategoriaDaoComEfCore>();
            //falando para o .net Core que onde estiver ILeilaoDao (construtor), será instanciado o LeiaoDaoComEFCore
            services.AddTransient<ILeilaoDao, LeilaoDaoComEFCore>();
            services.AddTransient<IProdutoService, DefaultProdutoService>();
            services.AddDbContext<AppDbContext>();
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
