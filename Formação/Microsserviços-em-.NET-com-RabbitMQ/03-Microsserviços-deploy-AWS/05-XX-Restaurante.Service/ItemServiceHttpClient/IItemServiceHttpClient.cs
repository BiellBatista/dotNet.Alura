using _05_XX_Restaurante.Service.Dtos;

namespace _05_XX_Restaurante.Service.ItemServiceHttpClient;

public interface IItemServiceHttpClient
{
    public void EnviaRestauranteParaItemService(RestauranteReadDto readDto);
}