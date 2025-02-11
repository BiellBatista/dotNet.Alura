﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace _05_06_XX_CasaDoCodigo.RelatorioWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // a autenticação irá validar o token vindo do IdentityServer
            // além disso, irá garantir que é valido
            // autenticação básica é aquela que o usuário e a senha trafegam pela rede
            // iremos usar a autenticação ao portador: somente o token trafega
            services
                .AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.ApiName = "CasaDoCodigo.Relatorio";
                    options.ApiSecret = "511536EF-F270-4058-80CA-1C89C192F69A";
                    options.Authority = Configuration["CasaDoCodigoIdentityServerUrl"];
                    options.RequireHttpsMetadata = false;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication(); //aplicando a configuração de autenticação no pipeline da aplicação
            app.UseMvc();
        }
    }
}
