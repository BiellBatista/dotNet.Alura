﻿using _04_XX_Salvando_dados.API.Converters;
using _04_XX_Salvando_dados.API.Requests;
using _04_XX_Salvando_dados.Dados;
using Microsoft.AspNetCore.Mvc;

namespace _04_XX_Salvando_dados.API.Endpoints;

public static class EspecialidadeExtension
{
    public static void AddEndPointEspecialidade(this WebApplication app)
    {
        app.MapGet("/especialidades", async ([FromServices] EspecialidadeConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var especialidades = converter.EntityListToResponseList(contexto.Especialidades.ToList());
            return Results.Ok(especialidades);
        }).WithTags("Especialidade").WithOpenApi();

        app.MapPost("/especialidade", async ([FromServices] EspecialidadeConverter converter, [FromServices] FreelandoContext contexto, EspecialidadeRequest especialidadeRequest) =>
        {
            var especialidade = converter.RequestToEntity(especialidadeRequest);
            await contexto.Especialidades.AddAsync(especialidade);
            await contexto.SaveChangesAsync();
            return Results.Created($"/especialidade/{especialidade.Id}", especialidade);
        }).WithTags("Especialidade").WithOpenApi();

        app.MapPut("/especialidade/{id}", async ([FromServices] EspecialidadeConverter converter, [FromServices] FreelandoContext contexto, Guid id, EspecialidadeRequest especialidadeRequest) =>
        {
            var especialidade = await contexto.Especialidades.FindAsync(id);
            if (especialidade is null)
            {
                return Results.NotFound();
            }
            var especialidadeAtualizada = converter.RequestToEntity(especialidadeRequest);
            especialidade.Descricao = especialidadeAtualizada.Descricao;
            especialidade.Projetos = especialidadeAtualizada.Projetos;
            await contexto.SaveChangesAsync();
            return Results.Ok(especialidade);
        }).WithTags("Especialidade").WithOpenApi();

        /*app.MapDelete("/especialidade/{id}", async ([FromServices] EspecialidadeConverter converter, [FromServices] FreelandoContext contexto, Guid id) =>
        {
            var especialidade = await contexto.Especialidades.FindAsync(id);
            if (especialidade is null)
            {
                return Results.NotFound();
            }
            contexto.Especialidades.Remove(especialidade);
            await contexto.SaveChangesAsync();
            return Results.NoContent();
        }).WithTags("Especialidade").WithOpenApi();*/

        app.MapDelete("/especialidade/{id}", async ([FromServices] EspecialidadeConverter converter, [FromServices] FreelandoContext contexto, Guid id) =>
        {
            using (var trasaction = contexto.Database.BeginTransaction())
            {
                try
                {
                    var especialidade = await contexto.Especialidades.FindAsync(id);
                    if (especialidade is null)
                    {
                        return Results.NotFound();
                    }
                    contexto.Especialidades.Remove(especialidade);
                    await contexto.SaveChangesAsync();
                    trasaction.Commit();
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    trasaction.Rollback();
                    throw ex;
                }
            }
        }).WithTags("Especialidade").WithOpenApi();
    }
}