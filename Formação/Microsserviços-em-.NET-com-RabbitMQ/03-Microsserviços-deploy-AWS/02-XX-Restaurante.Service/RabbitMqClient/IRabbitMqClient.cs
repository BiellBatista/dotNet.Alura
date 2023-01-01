using _02_XX_Restaurante.Service.Dtos;

namespace _02_XX_Restaurante.Service.RabbitMqClient;

public interface IRabbitMqClient
{
    void PublicaRestaurante(RestauranteReadDto restauranteReadDto);
}