using _05_XX_Boas_Praticas.Dtos;
using _05_XX_Boas_Praticas.Models;
using _05_XX_Boas_Praticas.Repositories;

namespace _05_XX_Boas_Praticas.Services;

public class TutorService
{
    private readonly TutorRepository _repository;

    public TutorService(TutorRepository repository)
    {
        _repository = repository;
    }

    public List<TutorDto> ListarTodos()
    {
        return _repository.GetAll().Select(tutor => new TutorDto(tutor)).ToList();
    }

    public void Cadastrar(CadastroTutorDto dados)
    {
        _repository.Add(new Tutor(dados));
    }
}