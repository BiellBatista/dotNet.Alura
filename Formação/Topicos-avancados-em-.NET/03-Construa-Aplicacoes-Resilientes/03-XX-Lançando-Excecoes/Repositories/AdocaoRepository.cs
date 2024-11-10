using _03_XX_Lançando_Excecoes.Data;
using _03_XX_Lançando_Excecoes.Models;
using _03_XX_Lançando_Excecoes.Models.Enums;

namespace _03_XX_Lançando_Excecoes.Repositories;

public class AdocaoRepository
{
    private readonly AdopetContext _dbContext;

    public AdocaoRepository(AdopetContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Adocao? GetById(long id)
    {
        return _dbContext.Adocoes.FirstOrDefault(a => a.Id == id);
    }

    public IEnumerable<Adocao> GetAll()
    {
        return _dbContext.Adocoes.ToList();
    }

    public void Add(Adocao adocao)
    {
        _dbContext.Adocoes.Add(adocao);
        _dbContext.SaveChanges();
    }

    public bool ExistsByPetIdAndStatus(long idPet, StatusAdocao statusAdocao)
    {
        return _dbContext.Adocoes.Any(a => a.Pet.Id == idPet && a.Status == statusAdocao);
    }

    public int CountByTutorIdAndStatus(long idTutor, StatusAdocao status)
    {
        return _dbContext.Adocoes.Count(a => a.TutorId == idTutor && a.Status == status);
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}