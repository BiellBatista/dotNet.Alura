using _02_XX_Excecoes_ADOPET_API.Dtos;
using _02_XX_Excecoes_ADOPET_API.Repositories;

namespace _02_XX_Excecoes_ADOPET_API.Services;

public class AdocaoService
{
    private readonly PetRepository _petRepository;
    private readonly TutorRepository _tutorRepository;
    private readonly AdocaoRepository _adocaoRepository;
    public AdocaoService(PetRepository petRepository, TutorRepository tutorRepository, AdocaoRepository adocaoRepository)
    {
        _petRepository = petRepository;
        _tutorRepository = tutorRepository;
        _adocaoRepository = adocaoRepository;
    }

    public List<AdocaoDto> ListarTodos()
    {
        return _adocaoRepository.GetAll().Select(adocao => new AdocaoDto(adocao)).ToList();
    }

    public AdocaoDto? Listar(long id)
    {
        var adocao = _adocaoRepository.GetById(id);
        return adocao != null ? new AdocaoDto(adocao) : null;
    }

    public void Solicitar(SolicitacaoDeAdocaoDto dto)
    {
        var pet = _petRepository.GetById(dto.IdPet);
        var tutor = _tutorRepository.GetById(dto.IdTutor);

        if (pet == null || tutor == null)
        {
            throw new NullReferenceException();
        }

        _adocaoRepository.Add(new Adocao(tutor, pet, dto.Motivo));
    }

    public void Aprovar(AprovarAdocaoDto dto)
    {
        var adocao = _adocaoRepository.GetById(dto.IdAdocao);
        adocao.MarcarComoAprovada();
        adocao.Pet.MarcarComoAdotado();
        _adocaoRepository.SaveChanges();
    }

    public void Reprovar(ReprovarAdocaoDto dto)
    {
        var adocao = _adocaoRepository.GetById(dto.IdAdocao);
        adocao.MarcarComoReprovada(dto.Justificativa);
        _adocaoRepository.SaveChanges();
    }
}