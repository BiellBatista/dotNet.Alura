using _04_XX_Hierarquia_Excecoes.Dtos;
using _04_XX_Hierarquia_Excecoes.Models;
using _04_XX_Hierarquia_Excecoes.Repositories;

namespace _04_XX_Hierarquia_Excecoes.Services;

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