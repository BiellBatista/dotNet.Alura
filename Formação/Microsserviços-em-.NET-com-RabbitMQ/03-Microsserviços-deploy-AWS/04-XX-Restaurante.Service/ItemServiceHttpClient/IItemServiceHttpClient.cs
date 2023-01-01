using _04_XX_Restaurante.Service.Dtos;

namespace _04_XX_Restaurante.Service.ItemServiceHttpClient;

public interface IItemServiceHttpClient
{
    public void EnviaRestauranteParaItemService(RestauranteReadDto readDto);
}