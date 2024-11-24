Task<string> conteudoTask = Task.Run(() => File.ReadAllText("voos.txt"));

void LerArquivo()
{
    try
    {
        Task.Delay(new Random().Next(300, 8000));

        Console.WriteLine($"Conteúdo: \n{conteudoTask.Result}");
    }
    catch (AggregateException ex)
    {
        Console.WriteLine($"Aconteceu o erro: {ex.InnerException?.Message}");
    }
}

static void ExibirRelatorio()
{
    Console.WriteLine("Executando relatório de compra de passagens!");

    Task.Delay(new Random().Next(300, 8000));
}
// executa uma tarefa em paralelo (encapsula toda complexidade de trabalhar com thread)
Task task1 = Task.Run(() => LerArquivo());
// executa uma tarefa em paralelo (encapsula toda complexidade de trabalhar com thread)
Task task2 = Task.Run(() => ExibirRelatorio());

Console.WriteLine("Outras operações.");
Console.ReadKey();