using _07_Simulando_cancelamento.Console.Client;
using _07_Simulando_cancelamento.Console.Modelos;

var client = new JornadaMilhasClient(new JornadaMilhasClientFactory().CreateClient());

async Task ProcessarConsultasDeVoosAsync()
{
    try
    {
        var tokenSource = new CancellationTokenSource();

        tokenSource.Cancel();

        var voos = await client.ConsultarVoosAsync(tokenSource.Token);

        if (voos is not null)
            foreach (var voo in voos)
                Console.WriteLine(voo);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"tarefa cancelada: {ex.Message}");
    }
}

await ProcessarConsultasDeVoosAsync();

async Task ComprarPassagemAsync()
{
    var compraPassagemRequest = new CompraPassagemRequest() { Origem = "Vitória", Destino = "Belém", Milhas = 1000 };
    var resultado = await client.ComprarPassagemAsync(compraPassagemRequest);

    Console.WriteLine(resultado);
}

await ComprarPassagemAsync();