using _02_03_Identificando_areas_funcionais.API.Domain;

namespace _02_03_Identificando_areas_funcionais.API.Responses;

public record ConteinerResponse(string Id, string Status, string? Observacoes)
{
    public static ConteinerResponse From(Conteiner conteiner) => new(
        Id: conteiner.Id.ToString(),
        Status: conteiner.Status.ToString(),
        Observacoes: conteiner.Observacoes
    );
}