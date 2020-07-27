namespace _07_06_XX_Aplicando_Heranca_Delegacao_Refatoracao.R60.ExtractInterface.depois
{
    public interface IFormatter
    {
        bool CanBeFormatted(string value);
        string Format(string value);
        bool IsFormatted(string value);
        string Unformat(string value);
    }
}