using _04_XX_Restaurante.Service.Models;

namespace _04_XX_Restaurante.Service.Data
{
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly AppDbContext _context;

        public RestauranteRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateRestaurante(Restaurante restaurante)
        {
            if (restaurante is null) throw new ArgumentNullException(nameof(restaurante));

            _context.Restaurantes.Add(restaurante);
        }

        public IEnumerable<Restaurante> GetAllRestaurantes() => _context.Restaurantes.ToList();

        public Restaurante GetRestauranteById(int id) => _context.Restaurantes.FirstOrDefault(c => c.Id == id);

        public void SaveChanges() => _context.SaveChanges();
    }
}