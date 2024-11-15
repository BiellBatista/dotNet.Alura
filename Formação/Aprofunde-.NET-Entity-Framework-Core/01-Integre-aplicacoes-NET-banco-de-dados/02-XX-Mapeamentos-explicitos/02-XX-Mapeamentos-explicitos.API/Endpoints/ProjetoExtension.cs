using _02_XX_Mapeamentos_explicitos.API.Converters;

namespace _02_XX_Mapeamentos_explicitos.API.Endpoints;

public static class ProjetoExtension
{
    public static void AddEndPointProjeto(this WebApplication app)
    {
        app.MapGet("/projetos", async ([FromServices] ProjetoConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var projetos = converter.EntityListToResponseList(contexto.Projetos.ToList());
            return Results.Ok(await Task.FromResult(projetos));
        }).WithTags("Projeto").WithOpenApi();
    }
}