namespace _01_03_XX_Padroes_Projeto_Command.Console.Comandos;

internal interface IComando
{
    Task ExecutarAsync(string[] args);
}