using _03_XX_Relacionamentos.API.Converters;
using _03_XX_Relacionamentos.Dados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _03_XX_Relacionamentos.API.Endpoints;

public static class ProjetoExtension
{
    public static void AddEndPointProjeto(this WebApplication app)
    {
        app.MapGet("/projetos", async ([FromServices] ProjetoConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var projetos = converter.EntityListToResponseList(contexto.Projetos.Include(p => p.Cliente).Include(p => p.Especialidades).ToList());
            return Results.Ok(await Task.FromResult(projetos));
        }).WithTags("Projeto").WithOpenApi();
    }
}