using _10_04_XX_Criando_Pipeline_Azure_Devops.API.DTO.Request;
using _10_04_XX_Criando_Pipeline_Azure_Devops.API.DTO.Response;
using _10_04_XX_Criando_Pipeline_Azure_Devops.Dominio.ValueObjects;

namespace _10_04_XX_Criando_Pipeline_Azure_Devops.API.Service;

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