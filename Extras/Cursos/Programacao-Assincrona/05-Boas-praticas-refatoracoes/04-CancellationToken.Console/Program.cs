using _07_Consumindo_API.Console.Client;
using _07_Consumindo_API.Console.Modelos;

var client = new JornadaMilhasClient(new JornadaMilhasClientFactory().CreateClient());

async Task ProcessarConsultasDeVoosAsync()
{
    var voos = await client.ConsultarVoosAsync();

    if (voos is not null)
        foreach (var voo in voos)
            Console.WriteLine(voo);
}

await ProcessarConsultasDeVoosAsync();

async Task ComprarPassagemAsync()
{
    var compraPassagemRequest = new CompraPassagemRequest() { Origem = "Vitória", Destino = "Belém", Milhas = 1000 };
    var resultado = await client.ComprarPassagemAsync(compraPassagemRequest);

    Console.WriteLine(resultado);
}

await ComprarPassagemAsync();