using _03_XX_Relacionamentos.API.Converters;
using _03_XX_Relacionamentos.Dados;
using Microsoft.AspNetCore.Mvc;

namespace _03_XX_Relacionamentos.API.Endpoints;

public static class CandidaturaExtension
{
    public static void AddEndPointCandidatura(this WebApplication app)
    {
        app.MapGet("/candidaturas", async ([FromServices] CandidaturaConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var candidatura = converter.EntityListToResponseList(contexto.Candidaturas.ToList());
            var entries = contexto.ChangeTracker.Entries();
            return Results.Ok(await Task.FromResult(candidatura));
        }).WithTags("Candidatura").WithOpenApi();
    }
}