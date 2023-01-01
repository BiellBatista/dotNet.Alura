using System.Collections.Generic;
using _05_XX_Item.Service.Models;

namespace _05_XX_Item.Service.Data;

public interface IItemRepository
{
    void SaveChanges();

    IEnumerable<Restaurante> GetAllRestaurantes();
    void CreateRestaurante(Restaurante restaurante);
    bool RestauranteExiste(int restauranteId);
    bool ExisteRestauranteExterno(int restauranteIdExterno);
    IEnumerable<Item> GetItensDeRestaurante(int restauranteId);
    Item GetItem(int restauranteId, int itemId);
    void CreateItem(int restauranteId, Item item);
}
