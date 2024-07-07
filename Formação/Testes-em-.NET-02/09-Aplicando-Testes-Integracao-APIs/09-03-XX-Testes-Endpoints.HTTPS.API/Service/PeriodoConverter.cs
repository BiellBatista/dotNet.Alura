using _09_03_XX_Testes_Endpoints.HTTPS.API.DTO.Request;
using _09_03_XX_Testes_Endpoints.HTTPS.API.DTO.Response;
using _09_03_XX_Testes_Endpoints.HTTPS.Dominio.ValueObjects;

namespace _09_03_XX_Testes_Endpoints.HTTPS.API.Service;

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