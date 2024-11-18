using _01_XX_Melhorando_consultas.API.Requests;
using _01_XX_Melhorando_consultas.API.Responses;
using _01_XX_Melhorando_consultas.Modelos;

namespace _01_XX_Melhorando_consultas.API.Converters;

public class EspecialidadeConverter
{
    private ProjetoConverter? _projetosConverter;
    private ProfissionalConverter? _profissionalConverter;

    public EspecialidadeResponse EntityToResponse(Especialidade? especialidade)
    {
        _projetosConverter = new ProjetoConverter();
        if (especialidade == null) { new EspecialidadeResponse(Guid.Empty, ""); }
        return new EspecialidadeResponse(especialidade.Id, especialidade.Descricao);
    }

    public Especialidade RequestToEntity(EspecialidadeRequest? especialidade)
    {
        _projetosConverter = new ProjetoConverter();
        _profissionalConverter = new ProfissionalConverter();

        if (especialidade == null) { return new Especialidade(Guid.Empty, "", new List<Projeto>(), new List<Profissional>()); }
        return new Especialidade(especialidade.Id, especialidade.Descricao, _projetosConverter.RequestListToEntityList(especialidade.Projetos), _profissionalConverter.RequestListToEntityList(especialidade.Profissionais));
    }

    public ICollection<EspecialidadeResponse> EntityListToResponseList(IEnumerable<Especialidade>? especialidades)
    {
        if (especialidades is null) { return new List<EspecialidadeResponse>(); }
        return especialidades.Select(a => EntityToResponse(a)).ToList();
    }

    public ICollection<Especialidade> RequestListToEntityList(IEnumerable<EspecialidadeRequest>? especialidades)
    {
        if (especialidades is null) { return new List<Especialidade>(); }
        return especialidades.Select(a => RequestToEntity(a)).ToList();
    }
}