using _04_XX_Hierarquia_Excecoes.Data;
using _04_XX_Hierarquia_Excecoes.Models;

namespace _04_XX_Hierarquia_Excecoes.Repositories;

public class TutorRepository
{
    private readonly AdopetContext _dbContext;

    public TutorRepository(AdopetContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Tutor? GetById(long id)
    {
        return _dbContext.Tutores.FirstOrDefault(t => t.Id == id);
    }

    public IEnumerable<Tutor> GetAll()
    {
        return _dbContext.Tutores.ToList();
    }

    public void Add(Tutor tutor)
    {
        _dbContext.Tutores.Add(tutor);
        _dbContext.SaveChanges();
    }
}