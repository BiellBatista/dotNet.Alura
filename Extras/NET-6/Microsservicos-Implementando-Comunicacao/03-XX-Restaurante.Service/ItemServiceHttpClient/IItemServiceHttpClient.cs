using _03_XX_Restaurante.Service.Dtos;

namespace _03_XX_Restaurante.Service.ItemServiceHttpClient;

public interface IItemServiceHttpClient
{
    public void EnviaRestauranteParaItemService(RestauranteReadDto restauranteReadDto);
}