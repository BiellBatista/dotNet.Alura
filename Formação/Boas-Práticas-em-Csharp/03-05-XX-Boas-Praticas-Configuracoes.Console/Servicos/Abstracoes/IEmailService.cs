namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;

public interface IEmailService
{
    Task SendMessageAsync(string destinatario, string titulo, string corpo, string remetente);
}