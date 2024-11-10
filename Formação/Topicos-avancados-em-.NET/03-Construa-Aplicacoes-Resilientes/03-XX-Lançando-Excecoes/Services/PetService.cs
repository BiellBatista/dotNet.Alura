using _03_XX_Lançando_Excecoes.Dtos;
using _03_XX_Lançando_Excecoes.Models;
using _03_XX_Lançando_Excecoes.Repositories;

namespace _03_XX_Lançando_Excecoes.Services;

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