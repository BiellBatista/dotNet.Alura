﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace _05_06_XX_CasaDoCodigo.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("CasaDoCodigo.Relatorio", "Serviço de relatório de vendas")
            };
        }

        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            string casaDoCodigoMvcUrl = configuration["CasaDoCodigoMvcUrl"];

            return new[]
            {
                // client credentials flow client
                new Client
                {
                    ClientId = "client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "api1" }
                },

                // MVC client using hybrid flow
                // configurando o client MVC que pode acessar o IdentityServer
                new Client
                {
                    ClientId = "CasaDoCodigo.MVC",
                    ClientName = "Casa do Código MVC",

                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    RedirectUris = { $"{casaDoCodigoMvcUrl}/signin-oidc" },
                    FrontChannelLogoutUri = $"{casaDoCodigoMvcUrl}/signout-oidc",
                    PostLogoutRedirectUris = { $"{casaDoCodigoMvcUrl}/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    // permissão da aplicação MVC
                    AllowedScopes = { "openid", "profile", "email", "CasaDoCodigo.Relatorio" }
                    // "openid", "profile" são o escopo do OpenIdConnect (id_token)
                    // CasaDoCodigo.Relatorio é o escopo do OAuth (access_token)
                },

                // SPA client using implicit flow
                new Client
                {
                    ClientId = "spa",
                    ClientName = "SPA Client",
                    ClientUri = "http://identityserver.io",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =
                    {
                        "http://localhost:5002/index.html",
                        "http://localhost:5002/callback.html",
                        "http://localhost:5002/silent.html",
                        "http://localhost:5002/popup.html",
                    },

                    PostLogoutRedirectUris = { "http://localhost:5002/index.html" },
                    AllowedCorsOrigins = { "http://localhost:5002" },

                    AllowedScopes = { "openid", "profile", "api1" }
                }
            };
        }
    }
}