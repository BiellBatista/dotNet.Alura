﻿using _05_XX_Consultas.API.Converters;
using _05_XX_Consultas.API.Requests;
using _05_XX_Consultas.Dados;
using Microsoft.AspNetCore.Mvc;

namespace _05_XX_Consultas.API.Endpoints;

public static class ServicoExtensions
{
    public static void AddEndPointServico(this WebApplication app)
    {
        app.MapGet("/servicos", async ([FromServices] ServicoConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var servico = converter.EntityListToResponseList(contexto.Servicos.ToList());
            return Results.Ok(await Task.FromResult(servico));
        }).WithTags("Servico").WithOpenApi();

        app.MapPost("/servico", async ([FromServices] ServicoConverter converter, [FromServices] FreelandoContext contexto, ServicoRequest servicoRequest) =>
        {
            var servico = converter.RequestToEntity(servicoRequest);
            await contexto.Servicos.AddAsync(servico);
            await contexto.SaveChangesAsync();
            return Results.Created($"/servico/{servico.Id}", servico);
        }).WithTags("Servico").WithOpenApi();

        app.MapPut("/servico/{id}", async ([FromServices] ServicoConverter converter, [FromServices] FreelandoContext contexto, Guid id, ServicoRequest servicoRequest) =>
        {
            var servico = await contexto.Servicos.FindAsync(id);
            if (servico is null)
            {
                return Results.NotFound();
            }
            var servicoAtualizado = converter.RequestToEntity(servicoRequest);
            servico.Titulo = servicoAtualizado.Titulo;
            servico.Descricao = servicoAtualizado.Descricao;
            servico.Status = servicoAtualizado.Status;
            await contexto.SaveChangesAsync();
            return Results.Ok(servico);
        }).WithTags("Servico").WithOpenApi();

        app.MapDelete("/servico/{id}", async ([FromServices] ServicoConverter converter, [FromServices] FreelandoContext contexto, Guid id) =>
        {
            var servico = await contexto.Servicos.FindAsync(id);
            if (servico is null)
            {
                return Results.NotFound();
            }
            contexto.Servicos.Remove(servico);
            await contexto.SaveChangesAsync();
            return Results.NoContent();
        }).WithTags("Servico").WithOpenApi();
    }
}