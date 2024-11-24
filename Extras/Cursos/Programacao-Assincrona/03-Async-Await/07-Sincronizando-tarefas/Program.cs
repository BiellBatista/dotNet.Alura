var chave = new object();
Task<string>? conteudoTask = null;

lock (chave)
{
    conteudoTask = Task.Run(() => File.ReadAllTextAsync("voos.txt"));
}

// uma função async sempre deve retornar uma Task<T>
async Task LerArquivoAsync(CancellationToken token)
{
    try
    {
        await Task.Delay(new Random().Next(300, 8000));

        Console.WriteLine($"Conteúdo: \n{conteudoTask.Result}");

        token.ThrowIfCancellationRequested();
    }
    catch (OperationCanceledException ex)
    {
        Console.WriteLine($"Tarefa cancelada: {ex.Message}");
    }
    catch (AggregateException ex)
    {
        Console.WriteLine($"Aconteceu o erro: {ex.InnerException?.Message}");
    }
}

// uma função async sempre deve retornar uma Task<T>
static async Task ExibirRelatorioAsync(CancellationToken token)
{
    try
    {
        Console.WriteLine("Executando relatório de compra de passagens!");

        await Task.Delay(new Random().Next(300, 8000));

        token.ThrowIfCancellationRequested();
    }
    catch (OperationCanceledException ex)
    {
        Console.WriteLine($"Tarefa cancelada: {ex.Message}");
    }
}

var tokenDeCancelamento = new CancellationTokenSource();
var tarefa = Task.WhenAll(LerArquivoAsync(tokenDeCancelamento.Token), ExibirRelatorioAsync(tokenDeCancelamento.Token));

await Task.Delay(1000).ContinueWith(_ => tokenDeCancelamento.Cancel());

Console.WriteLine("Outras operações.");
Console.ReadKey();