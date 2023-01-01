using _04_XX_Restaurante.Service.Models;

namespace _04_XX_Restaurante.Service.Data;

public interface IRestauranteRepository
{
    void SaveChanges();

    IEnumerable<Restaurante> GetAllRestaurantes();
    Restaurante GetRestauranteById(int id);
    void CreateRestaurante(Restaurante restaurante);
}
