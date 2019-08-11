using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Alura.WebAPI.Api.Filtros;
using Alura.WebAPI.Api.Formatters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;

namespace Alura.WebAPI.Api
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
            services.AddDbContext<LeituraContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ListaLeitura"));
            });

            services.AddTransient<IRepository<Livro>, RepositorioBaseEF<Livro>>();

            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new LivroCsvFormatter());
                options.Filters.Add(new ErroResponseFilter());//amarrando o meu filtro de erro
            }).AddXmlSerializerFormatters();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true; //esativando o filtro (validação) padrão do ModelState do MVC
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("alura-webapi-authentication-valid")),
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidIssuer = "Alura.WebApp",
                    ValidAudience = "Postman",
                };
            });

            services.AddApiVersioning();
            //configurando o swagger (Open API) para gerar a documentação
            services.AddSwaggerGen(c =>
            {
                //o primeiro argumento (v1), deve ser único, pois fará parte da URI
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Livros API",
                    Description = "Documentação da API de livros.",
                    Version = "1.0"
                }); //gerando uma documentação
                c.SwaggerDoc("v2", new Info
                {
                    Title = "Livros API",
                    Description = "Documentação da API de livros.",
                    Version = "2.0"
                });
            });

            services.AddSwaggerGen(options =>
            {
                //definição do esquema de segurança utilizado
                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey",
                    Description = "Autenticação Bearer via JWT"
                }); //configurando a informação de autenticação

                //que operações usam o esquema acima - todas
                options.AddSecurityRequirement(
                    new Dictionary<string, IEnumerable<string>> {
                        { "Bearer", new string[] { } }
                    });

                //descrevendo enumerados como strings
                options.DescribeAllEnumsAsStrings();
                options.DescribeStringEnumsInCamelCase();

                //adicionando o filtro para incluir respostas 401 nas operações
                options.OperationFilter<AuthResponsesOperationFilter>();

                //adicionando o filtro para incluir descrições nas tags
                options.DocumentFilter<TagDescriptionsDocumentFilter>();

                options.EnableAnnotations();
            }); //ativando as anotacoes extras do Swashbuckle
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger(); //usando o swagger, gera o .json
            app.UseSwaggerUI(c =>
            {
                //definindo os endpoint para as versões da documentação
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Versão 1.0");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Versão 2.0");
            }); //configurando a interface HTML da documentação. Ele usa o .json gerado
            //é necessário para a URI do .json gerado

            /**
             * Preciso alterar a porta de 6000 para 6001, pois o chrome considera a 6000 não segura
             */
        }
    }
}
