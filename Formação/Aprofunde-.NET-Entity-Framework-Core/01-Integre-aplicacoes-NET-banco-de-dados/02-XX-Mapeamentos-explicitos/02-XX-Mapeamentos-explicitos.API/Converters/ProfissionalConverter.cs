using _02_XX_Mapeamentos_explicitos.API.Requests;
using _02_XX_Mapeamentos_explicitos.API.Responses;

namespace _02_XX_Mapeamentos_explicitos.API.Converters;

public class ProfissionalConverter
{
    public ProfissionalResponse EntityToResponse(Profissional? profissional)
    {
        if (profissional == null)
        {
            return new ProfissionalResponse(Guid.Empty, null, null, null, null);
        }

        return new ProfissionalResponse(profissional.Id, profissional.Nome, profissional.Cpf, profissional.Email, profissional.Telefone);
    }

    public Profissional RequestToEntity(ProfissionalRequest? profissionalRequest)
    {
        if (profissionalRequest == null)
        {
            return new Profissional(Guid.Empty, null, null, null, null);
        }

        return new Profissional(profissionalRequest.Id, profissionalRequest.Nome, profissionalRequest.Cpf, profissionalRequest.Email, profissionalRequest.Telefone);
    }

    public ICollection<ProfissionalResponse> EntityListToResponseList(IEnumerable<Profissional> profissionais)
    {
        return (profissionais == null)
            ? new List<ProfissionalResponse>()
            : profissionais.Select(a => EntityToResponse(a)).ToList();
    }

    public ICollection<Profissional> RequestListToEntityList(IEnumerable<ProfissionalRequest> profissionalRequests)
    {
        if (profissionalRequests == null)
        {
            return new List<Profissional>();
        }

        return profissionalRequests.Select(a => RequestToEntity(a)).ToList();
    }
}