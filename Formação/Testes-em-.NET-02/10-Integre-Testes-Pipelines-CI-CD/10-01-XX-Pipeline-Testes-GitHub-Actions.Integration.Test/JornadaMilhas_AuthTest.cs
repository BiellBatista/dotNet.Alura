﻿namespace _10_01_XX_Pipeline_Testes_GitHub_Actions.Integration.Test;

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