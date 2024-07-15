using _10_02_XX_TestContainer.API.DTO.Request;
using _10_02_XX_TestContainer.API.DTO.Response;
using _10_02_XX_TestContainer.Dominio.ValueObjects;

namespace _10_02_XX_TestContainer.API.Service;

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