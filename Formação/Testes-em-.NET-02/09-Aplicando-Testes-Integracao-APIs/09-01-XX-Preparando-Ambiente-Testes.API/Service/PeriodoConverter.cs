using _09_01_XX_Preparando_Ambiente_Testes.API.DTO.Request;
using _09_01_XX_Preparando_Ambiente_Testes.API.DTO.Response;
using _09_01_XX_Preparando_Ambiente_Testes.Dominio.ValueObjects;

namespace _09_01_XX_Preparando_Ambiente_Testes.API.Service;

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