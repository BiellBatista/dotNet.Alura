using _01_XX_Conhecendo_Excecoes.Dtos;
using _01_XX_Conhecendo_Excecoes.Models;
using _01_XX_Conhecendo_Excecoes.Repositories;

namespace _01_XX_Conhecendo_Excecoes.Services;

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