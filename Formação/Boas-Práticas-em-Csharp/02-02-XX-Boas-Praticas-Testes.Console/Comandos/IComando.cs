namespace _02_02_XX_Boas_Praticas_Testes.Console.Comandos
{
    internal interface IComando
    {
        Task ExecutarAsync(string[] args);
    }
}