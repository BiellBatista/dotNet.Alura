using _10_03_XX_Publicando_Pipeline.API.DTO.Request;
using _10_03_XX_Publicando_Pipeline.API.DTO.Response;
using _10_03_XX_Publicando_Pipeline.Dominio.ValueObjects;

namespace _10_03_XX_Publicando_Pipeline.API.Service;

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