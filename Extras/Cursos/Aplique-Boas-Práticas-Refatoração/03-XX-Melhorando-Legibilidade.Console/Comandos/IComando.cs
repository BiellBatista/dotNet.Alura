namespace _03_XX_Melhorando_Legibilidade.Console.Comandos;

internal interface IComando
{
    Task ExecutarAsync(string[] args);
}