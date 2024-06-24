using _09_02_XX_Compartilhando_Contexto.Dominio.Entidades;
using _09_02_XX_Compartilhando_Contexto.Dominio.ValueObjects;
using System.Net;
using System.Net.Http.Json;

namespace _09_02_XX_Compartilhando_Contexto.Integration.Test
{
    public class OfertaViagem_POST
    {
        [Fact]
        public async Task Cadastra_OfertaViagem()
        {
            //Arrange
            var app = new JornadaMilhasWebApplicationFactory();
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
    }
}