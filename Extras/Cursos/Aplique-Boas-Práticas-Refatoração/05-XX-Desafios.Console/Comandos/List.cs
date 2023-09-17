using _04_XX_Testes_Automatizados.Console.Servicos;
using _05_XX_Desafios.Console.Modelos;

namespace _05_XX_Desafios.Console.Comandos;

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