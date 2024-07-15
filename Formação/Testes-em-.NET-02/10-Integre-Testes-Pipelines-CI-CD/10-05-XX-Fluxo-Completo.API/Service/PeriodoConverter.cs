using _10_05_XX_Fluxo_Completo.API.DTO.Request;
using _10_05_XX_Fluxo_Completo.API.DTO.Response;
using _10_05_XX_Fluxo_Completo.Dominio.ValueObjects;

namespace _10_05_XX_Fluxo_Completo.API.Service;

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