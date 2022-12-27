using _02_XX_Restaurante.Service.Dtos;

namespace _02_XX_Restaurante.Service.ItemServiceHttpClient;

public interface IItemServiceHttpClient
{
    public void EnviaRestauranteParaItemService(RestauranteReadDto restauranteReadDto);
}