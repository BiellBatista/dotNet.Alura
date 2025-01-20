using _07_Consumindo_API.Console.Client;

var client = new JornadaMilhasClient(new JornadaMilhasClientFactory().CreateClient());

async Task ProcessarConsultasDeVoosAsync()
{
    var voos = await client.ConsultarVoosAsync();

    if (voos is not null)
        foreach (var voo in voos)
            Console.WriteLine(voo);
}

await ProcessarConsultasDeVoosAsync();