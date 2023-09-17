namespace _04_XX_Testes_Automatizados.Console.Comandos;

internal interface IComando
{
    Task ExecutarAsync(string[] args);
}