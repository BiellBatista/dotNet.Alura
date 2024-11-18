namespace _05_XX_Interceptando_comandos.Dados.Interceptor;

public class CommandInterceptor : DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine($"Execução de comando: {command.CommandText} - Data/Hora: {DateTime.Now}");
        Console.BackgroundColor = ConsoleColor.White;
        return base.ReaderExecuting(command, eventData, result);
    }

    public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine($"Execução de comando: {command.CommandText} - Data/Hora: {{DateTime.Now}}");
        Console.BackgroundColor = ConsoleColor.White;
        return base.NonQueryExecuting(command, eventData, result);
    }
}