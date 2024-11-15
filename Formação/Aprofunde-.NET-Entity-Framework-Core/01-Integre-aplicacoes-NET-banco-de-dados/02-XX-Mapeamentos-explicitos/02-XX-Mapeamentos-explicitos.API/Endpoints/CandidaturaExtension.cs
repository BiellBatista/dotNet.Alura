using _02_XX_Mapeamentos_explicitos.API.Converters;

namespace _02_XX_Mapeamentos_explicitos.API.Endpoints;

public static class CandidaturaExtension
{
    public static void AddEndPointCandidatura(this WebApplication app)
    {
        app.MapGet("/candidaturas", async ([FromServices] CandidaturaConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var candidatura = converter.EntityListToResponseList(contexto.Candidaturas.AsNoTracking().ToList());
            var entries = contexto.ChangeTracker.Entries();
            return Results.Ok(await Task.FromResult(candidatura));
        }).WithTags("Candidatura").WithOpenApi();
    }
}