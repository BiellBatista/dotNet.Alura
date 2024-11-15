using _03_XX_Relacionamentos.API.Converters;
using _03_XX_Relacionamentos.Dados;
using Microsoft.AspNetCore.Mvc;

namespace _03_XX_Relacionamentos.API.Endpoints;

public static class ServicoExtensions
{
    public static void AddEndPointServico(this WebApplication app)
    {
        app.MapGet("/servicos", async ([FromServices] ServicoConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var servico = converter.EntityListToResponseList(contexto.Servicos.ToList());
            return Results.Ok(await Task.FromResult(servico));
        }).WithTags("Servicos").WithOpenApi();
    }
}