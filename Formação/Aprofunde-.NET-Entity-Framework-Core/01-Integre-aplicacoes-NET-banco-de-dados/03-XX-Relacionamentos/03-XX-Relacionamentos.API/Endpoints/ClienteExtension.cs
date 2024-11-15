using _03_XX_Relacionamentos.API.Converters;
using _03_XX_Relacionamentos.Dados;
using Microsoft.AspNetCore.Mvc;

namespace _03_XX_Relacionamentos.API.Endpoints;

public static class ClienteExtension
{
    public static void AddEndPointClientes(this WebApplication app)
    {
        app.MapGet("/clientes", async ([FromServices] ClienteConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var clientes = converter.EntityListToResponseList(contexto.Clientes.ToList());
            var entries = contexto.ChangeTracker.Entries();
            return Results.Ok(await Task.FromResult(clientes));
        }).WithTags("Cliente").WithOpenApi();
    }
}