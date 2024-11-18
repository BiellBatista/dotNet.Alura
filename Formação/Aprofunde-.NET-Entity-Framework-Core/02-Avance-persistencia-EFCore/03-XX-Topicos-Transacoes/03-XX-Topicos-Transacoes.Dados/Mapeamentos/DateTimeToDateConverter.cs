using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace _03_XX_Topicos_Transacoes.Dados.Mapeamentos;

public class DateTimeToDateConverter : ValueConverter<DateTime, DateOnly>
{
    public DateTimeToDateConverter() : base(
        d => DateOnly.FromDateTime(d),
        d => d.ToDateTime(TimeOnly.MinValue)
        )
    {
    }
}