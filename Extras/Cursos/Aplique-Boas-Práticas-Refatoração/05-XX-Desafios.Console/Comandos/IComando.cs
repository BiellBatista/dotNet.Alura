namespace _05_XX_Desafios.Console.Comandos;

internal interface IComando
{
    Task ExecutarAsync(string[] args);
}