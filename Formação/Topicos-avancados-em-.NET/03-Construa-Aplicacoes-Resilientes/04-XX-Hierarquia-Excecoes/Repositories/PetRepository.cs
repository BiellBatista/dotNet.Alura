using _04_XX_Hierarquia_Excecoes.Data;
using _04_XX_Hierarquia_Excecoes.Models;

namespace _04_XX_Hierarquia_Excecoes.Repositories;

public class PetRepository
{
    private readonly AdopetContext _dbContext;

    public PetRepository(AdopetContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Pet? GetById(long id)
    {
        return _dbContext.Pets.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Pet> GetAll()
    {
        return _dbContext.Pets.ToList();
    }

    public void Add(Pet pet)
    {
        _dbContext.Pets.Add(pet);
        _dbContext.SaveChanges();
    }
}