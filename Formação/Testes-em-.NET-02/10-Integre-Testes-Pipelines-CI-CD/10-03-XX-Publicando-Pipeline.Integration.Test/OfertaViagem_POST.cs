using _10_03_XX_Publicando_Pipeline.Dominio.Entidades;
using _10_03_XX_Publicando_Pipeline.Dominio.ValueObjects;
using System.Net;
using System.Net.Http.Json;

namespace _10_03_XX_Publicando_Pipeline.Integration.Test;

public class OfertaViagem_POST : IClassFixture<JornadaMilhasWebApplicationFactory>
{
    private readonly JornadaMilhasWebApplicationFactory app;

    public OfertaViagem_POST(JornadaMilhasWebApplicationFactory app)
    {
        this.app = app;
    }

    [Fact]
    public async Task Cadastra_OfertaViagem()
    {
        //Arrange

        using var client = await app.GetClientWithAccessTokenAsync();

        var ofertaViagem = new OfertaViagem()
        {
            Preco = 100,
            Rota = new Rota("Origem", "Destino"),
            Periodo = new Periodo(DateTime.Parse("2024-03-03"), DateTime.Parse("2024-03-06"))
        };

        //Act
        var response = await client.PostAsJsonAsync("/ofertas-viagem", ofertaViagem);

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Tenta_Cadastrar_OfertaViagem_SemAutorizacao()
    {
        //Arrange
        using var client = app.CreateClient();

        var ofertaViagem = new OfertaViagem()
        {
            Preco = 100,
            Rota = new Rota("Origem", "Destino"),
            Periodo = new Periodo(DateTime.Parse("2024-03-03"), DateTime.Parse("2024-03-06"))
        };

        //Act
        var response = await client.PostAsJsonAsync("/ofertas-viagem", ofertaViagem);

        //Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}