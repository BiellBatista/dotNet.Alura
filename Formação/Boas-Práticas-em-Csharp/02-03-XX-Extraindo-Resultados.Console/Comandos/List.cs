using _02_03_XX_Extraindo_Resultados.Console.Modelos;
using _02_03_XX_Extraindo_Resultados.Console.Servicos;
using FluentResults;

namespace _02_03_XX_Extraindo_Resultados.Console.Comandos
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

        public Task<Result> ExecutarAsync(string[] args)
        {
            return ListaDadosPetsDaAPIAsync();
        }

        private async Task<Result> ListaDadosPetsDaAPIAsync()
        {
            try
            {
                IEnumerable<Pet>? pets = await clientPet.ListPetsAsync();
                System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
                foreach (var pet in pets)
                {
                    System.Console.WriteLine(pet);
                }
                return Result.Ok();
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
            }
        }
    }
}