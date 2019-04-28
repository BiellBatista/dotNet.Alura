using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_04_XX_CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _02_04_XX_CasaDoCodigo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // esta classe adiciona e configura o serviço
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("Default");

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(connectionString)
            ); //adicionando o contexto do banco
            //implementando a injeção de depedênci, implementando a classe concreta da injeção
            services.AddTransient<IDataServices, DataServices>(); //adicionando uma instancia temporária
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
        }

        // este método é executado quando a aplicação subir
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //serve o contexto (banco de dados) da aplicação
        // este método usa os serviços configurados no método de cima
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pedido}/{action=Carrossel}/{id?}");
            });

            //criando o banco de dados do contexto ApplicationContext, caso o mesmo não esteja criado. Porém, ao usar este método, eu não consigo usar migrações
            //serviceProvider.GetService<ApplicationContext>().Database.EnsureCreated();
            // faz a mesma coisa que o de cima, mas posos usar migrações
            //serviceProvider.GetService<ApplicationContext>().Database.Migrate();

            //serviceProvider.GetService<IDataServices>().InicializaDB();
        }
    }
}
