namespace _05_XX_Interceptando_comandos.Dados.Mapeamentos;

public class DateTimeToDateConverter : ValueConverter<DateTime, DateOnly>
{
    public DateTimeToDateConverter() : base(
        d => DateOnly.FromDateTime(d),
        d => d.ToDateTime(TimeOnly.MinValue)
        )
    {
    }
}