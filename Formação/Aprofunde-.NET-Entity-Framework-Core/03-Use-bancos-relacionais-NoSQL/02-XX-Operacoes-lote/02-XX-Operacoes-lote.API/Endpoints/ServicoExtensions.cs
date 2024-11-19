using _02_XX_Operacoes_lote.API.Converters;
using _02_XX_Operacoes_lote.API.Requests;
using _02_XX_Operacoes_lote.Dados.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace _02_XX_Operacoes_lote.API.Endpoints;

public static class ServicoExtensions
{
    public static void AddEndPointServicos(this WebApplication app)
    {
        app.MapGet("/servicos", async ([FromServices] ServicoConverter converter, [FromServices] IUnitOfWork unitofOrk) =>
        {
            var servico = converter.EntityListToResponseList(await unitofOrk.ServicoRepository.BuscarTodos());

            return Results.Ok(await Task.FromResult(servico));
        }).WithTags("Servicos").WithOpenApi();

        app.MapPost("/servico", async ([FromServices] ServicoConverter converter, [FromServices] IUnitOfWork unitofOrk, ServicoRequest servicoRequest) =>
        {
            var servico = converter.RequestToEntity(servicoRequest);

            await unitofOrk.ServicoRepository.Adicionar(servico);
            await unitofOrk.Commit();

            return Results.Created($"/servico/{servico.Id}", servico);
        }).WithTags("Servicos").WithOpenApi();

        app.MapPut("/servico/{id}", async ([FromServices] ServicoConverter converter, [FromServices] IUnitOfWork unitofOrk, Guid id, ServicoRequest servicoRequest) =>
        {
            var servico = await unitofOrk.ServicoRepository.BuscarPorId(x => x.Id == id);
            if (servico is null)
            {
                return Results.NotFound();
            }
            var servicoAtualizado = converter.RequestToEntity(servicoRequest);
            servico.Titulo = servicoAtualizado.Titulo;
            servico.Descricao = servicoAtualizado.Descricao;
            servico.Status = servicoAtualizado.Status;

            await unitofOrk.ServicoRepository.Atualizar(servico);
            await unitofOrk.Commit();

            return Results.Ok(servico);
        }).WithTags("Servicos").WithOpenApi();

        app.MapDelete("/servico/{id}", async ([FromServices] ServicoConverter converter, [FromServices] IUnitOfWork unitofOrk, Guid id) =>
        {
            var servico = await unitofOrk.ServicoRepository.BuscarPorId(x => x.Id == id);
            if (servico is null)
            {
                return Results.NotFound();
            }

            await unitofOrk.ServicoRepository.Deletar(servico);
            await unitofOrk.Commit();

            return Results.NoContent();
        }).WithTags("Servicos").WithOpenApi();
    }
}