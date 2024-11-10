using _02_XX_Excecoes_ADOPET_API.Dtos;
using _02_XX_Excecoes_ADOPET_API.Models;
using _02_XX_Excecoes_ADOPET_API.Repositories;

namespace _02_XX_Excecoes_ADOPET_API.Services;

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