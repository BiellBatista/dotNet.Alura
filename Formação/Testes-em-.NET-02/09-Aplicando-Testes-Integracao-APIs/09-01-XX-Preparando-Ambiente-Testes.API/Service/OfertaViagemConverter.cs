﻿using _09_01_XX_Preparando_Ambiente_Testes.API.DTO.Request;
using _09_01_XX_Preparando_Ambiente_Testes.API.DTO.Response;
using _09_01_XX_Preparando_Ambiente_Testes.Dominio.Entidades;

namespace _09_01_XX_Preparando_Ambiente_Testes.API.Service;

public class OfertaViagemConverter
{
    private readonly RotaConverter rotaConverter;
    private readonly PeriodoConverter periodoConverter;

    public OfertaViagemConverter(RotaConverter rotaConverter, PeriodoConverter periodoConverter)
    {
        this.rotaConverter = rotaConverter;
        this.periodoConverter = periodoConverter;
    }

    public OfertaViagem RequestToEntity(OfertaViagemRequest ofertaViagemRequest)
    {
        if (ofertaViagemRequest.rota is null)
        {
            return new OfertaViagem(null, periodoConverter.RequestToEntity(ofertaViagemRequest.periodo), ofertaViagemRequest.preco);
        }
        if (ofertaViagemRequest.periodo is null)
        {
            return new OfertaViagem(rotaConverter.RequestToEntity(ofertaViagemRequest.rota), null, ofertaViagemRequest.preco);
        }
        if (ofertaViagemRequest.preco <= 0)
        {
            return new OfertaViagem(rotaConverter.RequestToEntity(ofertaViagemRequest.rota), periodoConverter.RequestToEntity(ofertaViagemRequest.periodo), ofertaViagemRequest.preco);
        }

        return new OfertaViagem(rotaConverter.RequestToEntity(ofertaViagemRequest.rota), periodoConverter.RequestToEntity(ofertaViagemRequest.periodo), ofertaViagemRequest.preco);
    }

    public OfertaViagemResponse EntityToResponse(OfertaViagem ofertaViagem)
    {
        return new OfertaViagemResponse(ofertaViagem.Id, rotaConverter.EntityToResponse(ofertaViagem.Rota), periodoConverter.EntityToResponse(ofertaViagem.Periodo), ofertaViagem.Preco, ofertaViagem.Desconto);
    }

    public ICollection<OfertaViagemResponse> EntityListToResponseList(IEnumerable<OfertaViagem> ofertas)
    {
        return ofertas.Select(a => EntityToResponse(a)).ToList();
    }

    public ICollection<OfertaViagem> RequestListToEntityList(IEnumerable<OfertaViagemRequest> ofertas)
    {
        return ofertas.Select(a => RequestToEntity(a)).ToList();
    }
}