using _03_XX_Lançando_Excecoes.Data;
using _03_XX_Lançando_Excecoes.Models;

namespace _03_XX_Lançando_Excecoes.Repositories;

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