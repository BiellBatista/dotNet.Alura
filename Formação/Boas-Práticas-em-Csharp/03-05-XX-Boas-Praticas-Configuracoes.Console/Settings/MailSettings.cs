namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Settings;

public class MailSettings
{
    public const string EmailSection = "AdopetEmailConfiguration";
    public string? Usuario { get; set; }
    public string? EmailAdmin { get; set; }
    public string? Senha { get; set; }
    public string? Servidor { get; set; }
    public int Porta { get; set; }
}