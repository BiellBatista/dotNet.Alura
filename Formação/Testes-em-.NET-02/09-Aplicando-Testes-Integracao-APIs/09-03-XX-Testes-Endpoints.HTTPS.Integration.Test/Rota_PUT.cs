using _09_03_XX_Testes_Endpoints.HTTPS.Dominio.Entidades;
using System.Net;
using System.Net.Http.Json;

namespace _09_03_XX_Testes_Endpoints.HTTPS.Integration.Test
{
    public class Rota_PUT : IClassFixture<JornadaMilhasWebApplicationFactory>
    {
        private readonly JornadaMilhasWebApplicationFactory app;

        public Rota_PUT(JornadaMilhasWebApplicationFactory app)
        {
            this.app = app;
        }

        [Fact]
        public async Task Atualiza_OfertaViagem_PorId()
        {
            //Arrange
            var rotaExistente = app.Context.Rota.FirstOrDefault();
            if (rotaExistente is null)
            {
                rotaExistente = new Rota()
                {
                    Origem = "Origem",
                    Destino = "Destino"
                };
                app.Context.Add(rotaExistente);
                app.Context.SaveChanges();
            }

            using var client = await app.GetClientWithAccessTokenAsync();

            rotaExistente.Origem = "Origem Atualizada";
            rotaExistente.Destino = "Destino Atualizada";

            //Act
            var response = await client.PutAsJsonAsync($"/rota-viagem/", rotaExistente);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}