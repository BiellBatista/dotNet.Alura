﻿namespace _03_06_XX_Enviando_Email.Console.Servicos.Abstracoes;

public interface IMailService
{
    Task SendMailAsync(string remetente, string destinatario,
        string titulo, string corpo);
}