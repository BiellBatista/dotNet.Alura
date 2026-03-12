using _05_04_Protegendo_subdominios_centrais.API.Domain;

namespace _05_04_Protegendo_subdominios_centrais.API.Conteineres;

public record ConteinerResponse(string Id, string Status, string? Observacoes)
{
    public static ConteinerResponse From(Conteiner conteiner) => new(
        Id: conteiner.Id.ToString(),
        Status: conteiner.Status.ToString(),
        Observacoes: conteiner.Observacoes
    );
}