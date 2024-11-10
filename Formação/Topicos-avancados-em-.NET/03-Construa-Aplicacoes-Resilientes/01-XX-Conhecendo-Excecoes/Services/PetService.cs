using _01_XX_Conhecendo_Excecoes.Dtos;
using _01_XX_Conhecendo_Excecoes.Models;
using _01_XX_Conhecendo_Excecoes.Repositories;

namespace _01_XX_Conhecendo_Excecoes.Services;

public class PetService
{
    private readonly PetRepository _repository;
    private readonly ImageStorageService _imagemService;

    public PetService(PetRepository repository, ImageStorageService imagemService)
    {
        _repository = repository;
        _imagemService = imagemService;
    }

    public List<PetDto> ListarTodos()
    {
        return _repository.GetAll().Select(pet => new PetDto(pet)).ToList();
    }

    public void Cadastrar(CadastroPetDto dto)
    {
        string nomeImagem = _imagemService.Upload(dto.Imagem);

        _repository.Add(new Pet(dto, nomeImagem));
    }
}