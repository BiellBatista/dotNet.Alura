﻿using _02_XX_Modelo_rico.API.Converters;
using _02_XX_Modelo_rico.API.Requests;
using _02_XX_Modelo_rico.Dados;
using Microsoft.AspNetCore.Mvc;

namespace _02_XX_Modelo_rico.API.Endpoints;

public static class ContratoExtensions
{
    public static void AddEndPointContratos(this WebApplication app)
    {
        app.MapGet("/contratos", async ([FromServices] ContratoConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var contrato = converter.EntityListToResponseList(contexto.Contratos.ToList());

            var entries = contexto.ChangeTracker.Entries();

            return Results.Ok(await Task.FromResult(contrato));
        }).WithTags("Contrato").WithOpenApi();

        app.MapPost("/contrato", async ([FromServices] ContratoConverter converter, [FromServices] FreelandoContext contexto, ContratoRequest contratoRequest) =>
        {
            var contrato = converter.RequestToEntity(contratoRequest);

            await contexto.Contratos.AddAsync(contrato);
            await contexto.SaveChangesAsync();

            return Results.Created($"/contrato/{contrato.Id}", contrato);
        }).WithTags("Contrato").WithOpenApi();

        app.MapPut("/contrato/{id}", async ([FromServices] ContratoConverter converter, [FromServices] FreelandoContext contexto, Guid id, ContratoRequest contratoRequest) =>
        {
            var contrato = await contexto.Contratos.FindAsync(id);
            if (contrato is null)
            {
                return Results.NotFound();
            }
            var contratoAtualizado = converter.RequestToEntity(contratoRequest);
            contrato.Valor = contratoAtualizado.Valor;
            contrato.Vigencia = contratoAtualizado.Vigencia;

            await contexto.SaveChangesAsync();

            return Results.Ok(contrato);
        }).WithTags("Contrato").WithOpenApi();

        app.MapDelete("/contrato/{id}", async ([FromServices] ContratoConverter converter, [FromServices] FreelandoContext contexto, Guid id) =>
        {
            var contrato = await contexto.Contratos.FindAsync(id);
            if (contrato is null)
            {
                return Results.NotFound();
            }

            contexto.Contratos.Remove(contrato);
            await contexto.SaveChangesAsync();

            return Results.NoContent();
        }).WithTags("Contrato").WithOpenApi();
    }
}