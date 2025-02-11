﻿using _04_03_XX_Estado_Autenticacao.API.Requests;
using _04_03_XX_Estado_Autenticacao.API.Response;
using _04_03_XX_Estado_Autenticacao.Shared.Dados.Banco;
using _04_03_XX_Estado_Autenticacao.Shared.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace _04_03_XX_Estado_Autenticacao.API.Endpoints;

public static class GeneroExtensions
{
    public static void AddEndPointGeneros(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("generos").RequireAuthorization().WithTags("Gêneros");
        groupBuilder.MapPost("", ([FromServices] DAL<Genero> dal, [FromBody] GeneroRequest generoReq) =>
        {
            dal.Adicionar(RequestToEntity(generoReq));
        });

        groupBuilder.MapGet("", ([FromServices] DAL<Genero> dal) =>
        {
            return EntityListToResponseList(dal.Listar());
        });

        groupBuilder.MapGet("{nome}", ([FromServices] DAL<Genero> dal, string nome) =>
        {
            var genero = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (genero is not null)
            {
                var response = EntityToResponse(genero!);
                return Results.Ok(response);
            }
            return Results.NotFound("Gênero não encontrado.");
        });

        groupBuilder.MapDelete("{id}", ([FromServices] DAL<Genero> dal, int id) =>
        {
            var genero = dal.RecuperarPor(a => a.Id == id);
            if (genero is null)
            {
                return Results.NotFound("Gênero para exclusão não encontrado.");
            }
            dal.Deletar(genero);
            return Results.NoContent();
        });
    }

    private static Genero RequestToEntity(GeneroRequest generoRequest)
    {
        return new Genero() { Nome = generoRequest.Nome, Descricao = generoRequest.Descricao };
    }

    private static ICollection<GeneroResponse> EntityListToResponseList(IEnumerable<Genero> generos)
    {
        return generos.Select(a => EntityToResponse(a)).ToList();
    }

    private static GeneroResponse EntityToResponse(Genero genero)
    {
        return new GeneroResponse(genero.Id, genero.Nome!, genero.Descricao!);
    }
}