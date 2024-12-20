﻿Task<string> conteudoTask = Task.Run(() => File.ReadAllTextAsync("voos.txt"));

// uma função async sempre deve retornar uma Task<T>
async Task LerArquivoAsync()
{
    try
    {
        await Task.Delay(new Random().Next(300, 8000));

        Console.WriteLine($"Conteúdo: \n{conteudoTask.Result}");
    }
    catch (AggregateException ex)
    {
        Console.WriteLine($"Aconteceu o erro: {ex.InnerException?.Message}");
    }
}

// uma função async sempre deve retornar uma Task<T>
static async Task ExibirRelatorioAsync()
{
    Console.WriteLine("Executando relatório de compra de passagens!");

    await Task.Delay(new Random().Next(300, 8000));
}

await Task.WhenAll(LerArquivoAsync(), ExibirRelatorioAsync());

Console.WriteLine("Outras operações.");
Console.ReadKey();