using _09_03_XX_Testes_Endpoints.HTTPS.Dominio.Entidades;
using _09_03_XX_Testes_Endpoints.HTTPS.Dominio.ValueObjects;
using System.Net.Http.Json;

namespace _09_03_XX_Testes_Endpoints.HTTPS.Integration.Test
{
    public class OfertaViagem_GET : IClassFixture<JornadaMilhasWebApplicationFactory>
    {
        private readonly JornadaMilhasWebApplicationFactory app;

        public OfertaViagem_GET(JornadaMilhasWebApplicationFactory app)
        {
            this.app = app;
        }

        [Fact]
        public async Task Recupera_OfertaViagem_PorId()
        {
            //Arrange
            var ofertaExistente = app.Context.OfertasViagem.FirstOrDefault();
            if (ofertaExistente is null)
            {
                ofertaExistente = new OfertaViagem()
                {
                    Preco = 100,
                    Rota = new Rota("Origem", "Destino"),
                    Periodo = new Periodo(DateTime.Parse("2024-03-03"), DateTime.Parse("2024-03-06"))
                };
                app.Context.Add(ofertaExistente);
                app.Context.SaveChanges();
            }

            using var client = await app.GetClientWithAccessTokenAsync();

            //Act
            var response = await client.GetFromJsonAsync<OfertaViagem>("/ofertas-viagem/" + ofertaExistente.Id);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(ofertaExistente.Preco, response.Preco, 0.001);
            Assert.Equal(ofertaExistente.Rota.Origem, response.Rota.Origem);
            Assert.Equal(ofertaExistente.Rota.Destino, response.Rota.Destino);
        }
    }
}