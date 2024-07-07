using _10_01_XX_Pipeline_Testes_GitHub_Actions.API.DTO.Request;
using _10_01_XX_Pipeline_Testes_GitHub_Actions.API.DTO.Response;
using _10_01_XX_Pipeline_Testes_GitHub_Actions.Dominio.ValueObjects;

namespace _10_01_XX_Pipeline_Testes_GitHub_Actions.API.Service;

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