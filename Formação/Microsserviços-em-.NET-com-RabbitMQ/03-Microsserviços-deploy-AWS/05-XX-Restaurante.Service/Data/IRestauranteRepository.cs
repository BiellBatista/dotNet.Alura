using _05_XX_Restaurante.Service.Models;

namespace _05_XX_Restaurante.Service.Data;

public interface IRestauranteRepository
{
    void SaveChanges();

    IEnumerable<Restaurante> GetAllRestaurantes();
    Restaurante GetRestauranteById(int id);
    void CreateRestaurante(Restaurante restaurante);
}
