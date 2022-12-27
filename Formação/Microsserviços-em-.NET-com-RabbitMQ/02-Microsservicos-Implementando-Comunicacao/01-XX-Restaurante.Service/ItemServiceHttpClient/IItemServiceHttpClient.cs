using _01_XX_Restaurante.Service.Dtos;

namespace _01_XX_Restaurante.Service.ItemServiceHttpClient;

public interface IItemServiceHttpClient
{
    public void EnviaRestauranteParaItemService(RestauranteReadDto restauranteReadDto);
}