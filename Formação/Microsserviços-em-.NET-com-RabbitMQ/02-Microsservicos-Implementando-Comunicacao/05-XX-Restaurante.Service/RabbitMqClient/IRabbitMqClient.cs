using _05_XX_Restaurante.Service.Dtos;

namespace _05_XX_Restaurante.Service.RabbitMqClient;

public interface IRabbitMqClient
{
    void PublicaRestaurante(RestauranteReadDto restauranteReadDto);
}