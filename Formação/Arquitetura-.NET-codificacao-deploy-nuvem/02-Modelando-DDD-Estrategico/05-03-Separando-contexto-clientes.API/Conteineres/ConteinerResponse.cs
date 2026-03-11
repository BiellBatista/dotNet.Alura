using _05_03_Separando_contexto_clientes.API.Domain;

namespace _05_03_Separando_contexto_clientes.API.Conteineres;

public record ConteinerResponse(string Id, string Status, string? Observacoes)
{
    public static ConteinerResponse From(Conteiner conteiner) => new(
        Id: conteiner.Id.ToString(),
        Status: conteiner.Status.ToString(),
        Observacoes: conteiner.Observacoes
    );
}