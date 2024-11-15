using _02_XX_Mapeamentos_explicitos.API.Converters;

namespace _02_XX_Mapeamentos_explicitos.API.Endpoints;

public static class ServicoExtensions
{
    public static void AddEndPointServico(this WebApplication app)
    {
        app.MapGet("/servicos", async ([FromServices] ServicoConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var servico = converter.EntityListToResponseList(contexto.Servicos.AsNoTracking().ToList());
            var entries = contexto.ChangeTracker.Entries();
            return Results.Ok(await Task.FromResult(servico));
        }).WithTags("Servicos").WithOpenApi();
    }
}