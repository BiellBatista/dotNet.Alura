﻿using _10_05_XX_Fluxo_Completo.API.DTO.Auth;
using System.Net;
using System.Net.Http.Json;

namespace _10_05_XX_Fluxo_Completo.Integration.Test;

public class JornadaMilhas_AuthTest : IClassFixture<JornadaMilhasWebApplicationFactory>
{
    private readonly JornadaMilhasWebApplicationFactory app;

    public JornadaMilhas_AuthTest(JornadaMilhasWebApplicationFactory app)
    {
        this.app = app;
    }

    [Fact]
    public async Task POST_Efetua_Login_Com_Sucesso()
    {
        //Arrange

        var user = new UserDTO { Email = "tester@email.com", Password = "Senha123@" };
        using var client = app.CreateClient();
        //Act
        var resultado = await client.PostAsJsonAsync("/auth-login", user);
        //Assert
        Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
    }
}