using _02_XX_Mapeamentos_explicitos.API.Converters;

namespace _02_XX_Mapeamentos_explicitos.API.Endpoints;

public static class ClienteExtension
{
    public static void AddEndPointClientes(this WebApplication app)
    {
        app.MapGet("/clientes", async ([FromServices] ClienteConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var clientes = converter.EntityListToResponseList(contexto.Clientes.AsNoTracking().ToList());
            var entries = contexto.ChangeTracker.Entries();
            return Results.Ok(await Task.FromResult(clientes));
        }).WithTags("Cliente").WithOpenApi();
    }
}