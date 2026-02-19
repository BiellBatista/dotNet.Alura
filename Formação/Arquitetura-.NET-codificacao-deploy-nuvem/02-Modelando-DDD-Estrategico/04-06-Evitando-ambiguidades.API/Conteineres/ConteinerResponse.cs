using _04_06_Evitando_ambiguidades.API.Domain;

namespace _04_06_Evitando_ambiguidades.API.Conteineres;

public record ConteinerResponse(string Id, string Status, string? Observacoes)
{
    public static ConteinerResponse From(Conteiner conteiner) => new(
        Id: conteiner.Id.ToString(),
        Status: conteiner.Status.ToString(),
        Observacoes: conteiner.Observacoes
    );
}