using _04_XX_Restaurante.Service.Dtos;

namespace _04_XX_Restaurante.Service.RabbitMqClient;

public interface IRabbitMqClient
{
    void PublicaRestaurante(RestauranteReadDto restauranteReadDto);
}