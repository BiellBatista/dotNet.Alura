namespace _01_05_XX_Desafios.Console.Comandos;

internal interface IComando
{
    Task ExecutarAsync(string[] args);
}