using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace _04_XX_Padroes_praticas.Dados.Mapeamentos;

public class DateTimeToDateConverter : ValueConverter<DateTime, DateOnly>
{
    public DateTimeToDateConverter() : base(
        d => DateOnly.FromDateTime(d),
        d => d.ToDateTime(TimeOnly.MinValue)
        )
    {
    }
}