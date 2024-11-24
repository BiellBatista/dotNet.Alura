using _09_Mao_massa;
using System.Text.Json;

static async Task<List<Voo>?> LerVoosDoArquivoJsonAsync(string caminhoArquivo)
{
    using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);

    return await JsonSerializer.DeserializeAsync<List<Voo>>(stream);
}

static async Task ProcessarVooAsync(Voo voo)
{
    // Simulação de algum processamento assíncrono (ex: gravação em banco, envio de email, etc.)
    await Task.Delay(1000); // Simula um atraso de 1 segundo para cada voo

    Console.WriteLine($"Voo: {voo.Id}, Origem: {voo.Origem}, Destino: {voo.Destino}, Preço: {voo.Preco}, Milhas: {voo.MilhasNecessarias}");
}

static async Task ProcessarVoosAsync()
{
    var caminhoArquivo = "voos.json";
    var voos = await LerVoosDoArquivoJsonAsync(caminhoArquivo);
    var tarefas = new List<Task>();

    if (voos is not null)
        foreach (var voo in voos)
            // Processa cada voo de forma assíncrona
            tarefas.Add(ProcessarVooAsync(voo));

    // Aguarda todas as tarefas terminarem
    await Task.WhenAll(tarefas);
}

await ProcessarVoosAsync();

Console.ReadKey();