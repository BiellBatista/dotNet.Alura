using _03_XX_Melhorando_Legibilidade.Console.Modelos;
using _03_XX_Melhorando_Legibilidade.Console.Servicos;

namespace _03_XX_Melhorando_Legibilidade.Console.Comandos;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
internal class List : IComando
{
    public Task ExecutarAsync(string[] args)
    {
        return ListaDadosPetsDaAPIAsync();
    }

    private async Task ListaDadosPetsDaAPIAsync()
    {
        var httpListPet = new HttpClientPet();
        IEnumerable<Pet>? pets = await httpListPet.ListPetsAsync();

        System.Console.WriteLine("----- Lista de Pets importados no sistema -----");

        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }
}