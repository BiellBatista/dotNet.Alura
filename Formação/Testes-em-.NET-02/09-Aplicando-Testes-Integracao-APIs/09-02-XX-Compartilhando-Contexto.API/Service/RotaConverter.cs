﻿using _09_02_XX_Compartilhando_Contexto.API.DTO.Request;
using _09_02_XX_Compartilhando_Contexto.API.DTO.Response;
using _09_02_XX_Compartilhando_Contexto.Dominio.Entidades;

namespace _09_02_XX_Compartilhando_Contexto.API.Service;

public class RotaConverter
{
    public Rota RequestToEntity(RotaRequest rotaRequest)
    {
        if (string.IsNullOrEmpty(rotaRequest.origem) || string.IsNullOrEmpty(rotaRequest.destino))
        {
            return new Rota(null, null);
        }
        return new Rota(rotaRequest.origem, rotaRequest.destino);
    }

    public RotaResponse EntityToResponse(Rota rota)
    {
        return new RotaResponse(rota.Id, rota.Origem!, rota.Destino!);
    }

    public ICollection<RotaResponse> EntityListToResponseList(IEnumerable<Rota> rotas)
    {
        return rotas.Select(a => EntityToResponse(a)).ToList();
    }

    public ICollection<Rota> RequestListToEntityList(IEnumerable<RotaRequest> rotas)
    {
        return rotas.Select(a => RequestToEntity(a)).ToList();
    }
}