using _03_XX_Lançando_Excecoes.Dtos;
using _03_XX_Lançando_Excecoes.Models;
using _03_XX_Lançando_Excecoes.Repositories;

namespace _03_XX_Lançando_Excecoes.Services;

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