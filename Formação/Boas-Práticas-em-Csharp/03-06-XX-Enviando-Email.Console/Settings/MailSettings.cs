namespace _03_06_XX_Enviando_Email.Console.Settings;

public class MailSettings
{
    public const string EmailSection = "AdopetEmailConfiguration";
    public string? Servidor { get; set; }
    public int Porta { get; set; }
    public string? Usuario { get; set; }
    public string? Senha { get; set; }
}