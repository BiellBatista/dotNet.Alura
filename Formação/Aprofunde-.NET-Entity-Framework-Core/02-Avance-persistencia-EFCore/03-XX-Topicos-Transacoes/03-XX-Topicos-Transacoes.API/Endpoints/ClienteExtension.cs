﻿using _03_XX_Topicos_Transacoes.API.Converters;
using _03_XX_Topicos_Transacoes.API.Requests;
using _03_XX_Topicos_Transacoes.Dados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace _03_XX_Topicos_Transacoes.API.Endpoints;

public static class ClienteExtension
{
    public static void AddEndPointClientes(this WebApplication app)
    {
        app.MapGet("/clientes", async ([FromServices] ClienteConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var clientes = converter.EntityListToResponseList(contexto.Clientes.ToList());

            return Results.Ok(await Task.FromResult(clientes));
        }).WithTags("Cliente").WithOpenApi();

        app.MapGet("/clientes/identificador-nome", async ([FromServices] ClienteConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var clientes = contexto.Clientes.Select(c => new { Identificador = c.Id, c.Nome });
            return Results.Ok(await Task.FromResult(clientes));
        }).WithTags("Cliente").WithOpenApi();

        app.MapGet("/clientes/projeto-especialidade", async ([FromServices] ClienteConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var clientes = contexto.Clientes.Include(x => x.Projetos).ThenInclude(p => p.Especialidades).AsSplitQuery().ToList();

            return Results.Ok(await Task.FromResult(clientes));
        }).WithTags("Cliente").WithOpenApi();

        app.MapGet("/clientes/por-email", async ([FromServices] ClienteConverter converter, [FromServices] FreelandoContext contexto, string email) =>
        {
            var clientes = contexto.Clientes.Where(c => c.Email.Equals(email)).ToList();

            return Results.Ok(await Task.FromResult(clientes));
        }).WithTags("Cliente").WithOpenApi();

        app.MapPost("/cliente", async ([FromServices] ClienteConverter converter, [FromServices] FreelandoContext contexto, ClienteRequest clienteRequest) =>
        {
            var cliente = converter.RequestToEntity(clienteRequest);
            await contexto.Clientes.AddAsync(cliente);
            await contexto.SaveChangesAsync();

            return Results.Created($"/cliente/{cliente.Id}", cliente);
        }).WithTags("Cliente").WithOpenApi();

        app.MapPut("/cliente/{id}", async ([FromServices] ClienteConverter converter, [FromServices] FreelandoContext contexto, Guid id, ClienteRequest clienteRequest) =>
        {
            var cliente = await contexto.Clientes.FindAsync(id);
            if (cliente is null)
            {
                return Results.NotFound();
            }
            var clienteAtualizado = converter.RequestToEntity(clienteRequest);
            cliente.Nome = clienteAtualizado.Nome;
            cliente.Cpf = clienteAtualizado.Cpf;
            cliente.Email = clienteAtualizado.Email;
            cliente.Telefone = clienteAtualizado.Telefone;

            await contexto.SaveChangesAsync();

            return Results.Ok(cliente);
        }).WithTags("Cliente").WithOpenApi();

        app.MapDelete("/cliente/{id}", async ([FromServices] ClienteConverter converter, [FromServices] FreelandoContext contexto, Guid id) =>
        {
            var cliente = await contexto.Clientes.FindAsync(id);
            if (cliente is null)
            {
                return Results.NotFound();
            }

            contexto.Clientes.Remove(cliente);
            await contexto.SaveChangesAsync();

            return Results.NoContent();
        }).WithTags("Cliente").WithOpenApi();

        app.MapPost("/clientes/new", async ([FromServices] ClienteConverter converter, [FromServices] FreelandoContext contexto, [FromServices] FreelandoClientesContext clientesContexto, ClienteRequest clienteRequest) =>
        {
            TransactionManager.ImplicitDistributedTransactions = true;

            using (var transactionScope = new TransactionScope(
           TransactionScopeOption.Required,
           new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                var cliente = converter.RequestToEntity(clienteRequest);
                cliente.Id = Guid.NewGuid();
                await contexto.Clientes.AddAsync(cliente);
                contexto.SaveChanges();

                var newCliente = new ClienteNew { Id = Guid.NewGuid(), Nome = cliente.Nome, Email = cliente.Email, DataInclusao = DateTime.Now };
                await clientesContexto.ClienteNew.AddAsync(newCliente);
                clientesContexto.SaveChanges();

                transactionScope.Complete();
                return Results.Created($"/clientes/{cliente.Id}", cliente);
            }
        }).WithTags("Cliente").WithOpenApi();
    }
}