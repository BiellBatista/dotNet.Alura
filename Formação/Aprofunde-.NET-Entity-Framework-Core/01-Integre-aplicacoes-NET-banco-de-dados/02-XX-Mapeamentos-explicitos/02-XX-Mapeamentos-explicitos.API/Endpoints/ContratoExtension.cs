using _02_XX_Mapeamentos_explicitos.API.Converters;

namespace _02_XX_Mapeamentos_explicitos.API.Endpoints;

public static class ContratoExtension
{
    public static void AddEndPointContrato(this WebApplication app)
    {
        app.MapGet("/contratos", async ([FromServices] ContratoConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var contrato = converter.EntityListToResponseList(contexto.Contratos.AsNoTracking().ToList());
            var entries = contexto.ChangeTracker.Entries();
            return Results.Ok(await Task.FromResult(contrato));
        }).WithTags("Contrato").WithOpenApi();
    }
}