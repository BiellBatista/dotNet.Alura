using _09_02_XX_Compartilhando_Contexto.API.DTO.Request;
using _09_02_XX_Compartilhando_Contexto.API.DTO.Response;
using _09_02_XX_Compartilhando_Contexto.Dominio.ValueObjects;

namespace _09_02_XX_Compartilhando_Contexto.API.Service;

public class PeriodoConverter
{
    public Periodo RequestToEntity(PeriodoRequest periodoRequest)
    {
        return new Periodo(periodoRequest.dataInicial, periodoRequest.dataFinal);
    }

    public PeriodoResponse EntityToResponse(Periodo periodo)
    {
        return new PeriodoResponse(periodo.DataInicial, periodo.DataFinal);
    }
}