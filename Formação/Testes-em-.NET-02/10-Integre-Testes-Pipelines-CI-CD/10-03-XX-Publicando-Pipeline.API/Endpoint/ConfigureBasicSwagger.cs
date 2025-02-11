﻿using Microsoft.OpenApi.Models;

namespace _10_03_XX_Publicando_Pipeline.API.Endpoint
{
    public static class ConfigureBasicSwagger
    {
        public static void ConfigureSwaggerBearer(this IServiceCollection services)
        {
            ConfigureAppServiceSwagger(services);
        }

        internal static void ConfigureAppServiceSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(
                        swagger =>
                        {
                            swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Jornada Milhas API", Version = "v1" });
                            swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                            {
                                Name = "Authorization",
                                Type = SecuritySchemeType.ApiKey,
                                Scheme = "Bearer",
                                BearerFormat = "JWT",
                                In = ParameterLocation.Header,
                                Description = "Header de autorização de esquema JWT usando Bearer.",
                            });
                            swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                            {
                                {
                                    new OpenApiSecurityScheme
                                    {
                                       Reference = new OpenApiReference
                                       {
                                           Type=ReferenceType.SecurityScheme,
                                           Id="Bearer"
                                       }
                                    },
                                    new string[]{}
                                }
                            });
                        });
        }
    }
}