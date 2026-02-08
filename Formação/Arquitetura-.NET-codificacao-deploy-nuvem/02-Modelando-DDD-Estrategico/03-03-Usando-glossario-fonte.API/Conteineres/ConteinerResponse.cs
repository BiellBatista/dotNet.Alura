using _03_03_Usando_glossario_fonte.API.Domain;

namespace _03_03_Usando_glossario_fonte.API.Conteineres;

public record ConteinerResponse(string Id, string Status, string? Observacoes)
{
    public static ConteinerResponse From(Conteiner conteiner) => new(
        Id: conteiner.Id.ToString(),
        Status: conteiner.Status.ToString(),
        Observacoes: conteiner.Observacoes
    );
}