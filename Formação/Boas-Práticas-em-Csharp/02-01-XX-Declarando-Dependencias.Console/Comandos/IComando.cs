namespace _01_XX_Declarando_Dependencias.Console.Comandos
{
    internal interface IComando
    {
        Task ExecutarAsync(string[] args);
    }
}