using _10_05_XX_Fluxo_Completo.Dominio.ValueObjects;
using Bogus;

namespace _10_05_XX_Fluxo_Completo.Integration.Test.DataBuilders;

internal class PeriodoDataBuilder : Faker<Periodo>
{
    public DateTime? DataInicial { get; set; }
    public DateTime? DataFinal { get; set; }

    public PeriodoDataBuilder()
    {
        CustomInstantiator(f =>
        {
            DateTime dataInicio = DataInicial ?? f.Date.Soon();
            DateTime dataFinal = DataFinal ?? dataInicio.AddDays(30);
            return new Periodo(dataInicio, dataFinal);
        });
    }

    public Periodo Build() => Generate();
}