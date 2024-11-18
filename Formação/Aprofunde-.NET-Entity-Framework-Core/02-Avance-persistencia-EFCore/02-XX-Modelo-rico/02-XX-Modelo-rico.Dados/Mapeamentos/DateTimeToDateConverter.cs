using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace _02_XX_Modelo_rico.Dados.Mapeamentos;

public class DateTimeToDateConverter : ValueConverter<DateTime, DateOnly>
{
    public DateTimeToDateConverter() : base(
        d => DateOnly.FromDateTime(d),
        d => d.ToDateTime(TimeOnly.MinValue)
        )
    {
    }
}