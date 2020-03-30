using _05_04_XX_CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace _05_04_XX_CasaDoCodigo
{
    public class Startup
    {
        private readonly ILoggerFactory _loggerFactory;

        public Startup(ILoggerFactory loggerFactory,
            IConfiguration configuration)
        {
            _loggerFactory = loggerFactory;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();

            string connectionString = Configuration.GetConnectionString("Default");

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString)
            );

            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IHttpHelper, HttpHelper>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<ICadastroRepository, CadastroRepository>();
            services.AddTransient<IRelatorioHelper, RelatorioHelper>();
            // adicionado o HttpFactory como depedência para RelatorioHelper
            services.AddHttpClient<IRelatorioHelper, RelatorioHelper>();

            // não será necessário usar o ASP.NET Core Identity, porque o Identity Server irá cuidar da autenticação/autorização
            //services.AddAuthentication()
            //    .AddMicrosoftAccount(options =>
            //    {
            //        options.ClientId = Configuration["ExternalLogin:Microsoft:ClientId"];
            //        options.ClientSecret = Configuration["ExternalLogin:Microsoft:ClientSecret"];
            //    })
            //    .AddGoogle(options =>
            //    {
            //        options.ClientId = Configuration["ExternalLogin:Google:ClientId"];
            //        options.ClientSecret = Configuration["ExternalLogin:Google:ClientSecret"];
            //    });

            services.AddAuthentication(options => {
                // forma de autenticação local do usuário
                options.DefaultScheme = "Cookies";
                // protocolo que define o fluxo de autenticação
                options.DefaultChallengeScheme = "OpenIdConnect";
            });
        }


        // Este método é chamado pelo runtime.
        // Use este método para configurar o pipeline de requisições HTTP.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IServiceProvider serviceProvider)
        {
            _loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            //adicionando o middleware do Identity ao meu pipelina
            /**
             * Correto. Cadeia de Responsabilidade é um padrão de design comportamental que permite passar requisições ao longo de uma cadeia de manipuladores. Ao receber uma requisição, cada manipulador decide processar a solicitação ou transmiti-la ao próximo manipulador da cadeia. No nosso caso, a “cadeia” é o pipeline do ASP.NET Core, e o manipulador é o “middleware” do ASP.NET Core Identity. 
             */
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pedido}/{action=BuscaProdutos}/{codigo?}");
            });

            var dataService = serviceProvider.GetRequiredService<IDataService>();
            dataService.InicializaDBAsync(serviceProvider).Wait();
        }
    }
}
