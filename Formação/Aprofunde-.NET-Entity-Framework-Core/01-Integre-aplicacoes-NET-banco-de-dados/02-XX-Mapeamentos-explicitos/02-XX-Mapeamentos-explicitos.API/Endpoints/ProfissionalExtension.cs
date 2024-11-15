using _02_XX_Mapeamentos_explicitos.API.Converters;

namespace _02_XX_Mapeamentos_explicitos.API.Endpoints;

public static class ProfissionalExtension
{
    public static void AddEndPointProfissional(this WebApplication app)
    {
        app.MapGet("/profissionais", async ([FromServices] ProfissionalConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var profissional = converter.EntityListToResponseList(contexto.Profissionais.AsNoTracking().ToList());
            var entries = contexto.ChangeTracker.Entries();
            return Results.Ok(await Task.FromResult(profissional));
        }).WithTags("Profissional").WithOpenApi();
    }
}