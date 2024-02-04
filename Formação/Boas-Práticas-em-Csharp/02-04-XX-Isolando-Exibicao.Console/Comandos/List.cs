using _02_04_XX_Isolando_Exibicao.Console.Modelos;
using _02_04_XX_Isolando_Exibicao.Console.Servicos;
using _02_04_XX_Isolando_Exibicao.Console.Util;
using FluentResults;

namespace _02_04_XX_Isolando_Exibicao.Console.Comandos
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
                return Result.Ok().WithSuccess(new SuccessWithPets(pets, "Listagem de Pet's realizada com sucesso!"));
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
            }
        }
    }
}