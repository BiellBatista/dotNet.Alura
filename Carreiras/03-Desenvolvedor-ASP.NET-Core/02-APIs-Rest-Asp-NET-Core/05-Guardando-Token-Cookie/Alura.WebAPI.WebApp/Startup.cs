using Alura.ListaLeitura.Seguranca;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Alura.WebAPI.WebApp.Formatters;
using Alura.WebAPI.WebApp.HttpClients;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Alura.ListaLeitura.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AuthDB"));
            });

            //configurando o uso do Identity
            //services.AddIdentity<Usuario, IdentityRole>(options =>
            //{
            //    options.Password.RequiredLength = 3;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireLowercase = false;
            //}).AddEntityFrameworkStores<AuthDbContext>();

            //mudandando o uso de autenticação do Identity para o Cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/Usuario/Login"; //informando o caminho de autenticação
                });

            services.AddHttpContextAccessor(); //adicionado a necessidade de usar o HttpContext fora do contexto

            //amarrando o httpclient para consumir a API de livros
            services.AddHttpClient<LivroApiClient>(client =>
            {
                client.BaseAddress = new System.Uri("http://localhost:6000/api/");
            });

            //amarrando o httpclient para consumir a API de autenticação
            services.AddHttpClient<AuthApiClient>(client =>
            {
                client.BaseAddress = new System.Uri("http://localhost:5000/api/"); //adicionando o corpo básio, com isso não preciso repetir nas URI das requisições
            });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = "/Usuario/Login";
            //});

            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new LivroCsvFormatter());
            }).AddXmlSerializerFormatters();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
