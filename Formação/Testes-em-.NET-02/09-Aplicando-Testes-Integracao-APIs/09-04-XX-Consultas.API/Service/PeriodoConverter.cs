using _09_04_XX_Consultas.API.DTO.Request;
using _09_04_XX_Consultas.API.DTO.Response;
using _09_04_XX_Consultas.Dominio.ValueObjects;

namespace _09_04_XX_Consultas.API.Service;

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