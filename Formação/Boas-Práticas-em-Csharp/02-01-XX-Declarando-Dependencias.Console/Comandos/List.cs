using _01_XX_Declarando_Dependencias.Console.Modelos;
using _01_XX_Declarando_Dependencias.Console.Servicos;

namespace _01_XX_Declarando_Dependencias.Console.Comandos
{
    [DocComando(instrucao: "list",
      documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    internal class List : IComando
    {
        private readonly HttpClientPet clientPet;

        public List(HttpClientPet clientPet)
        {
            this.clientPet = clientPet;
        }

        public Task ExecutarAsync(string[] args)
        {
            return ListaDadosPetsDaAPIAsync();
        }

        private async Task ListaDadosPetsDaAPIAsync()
        {
            IEnumerable<Pet>? pets = await clientPet.ListPetsAsync();
            System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}