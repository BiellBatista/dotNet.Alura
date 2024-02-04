using _03_01_XX_Importando_Json.Console.Atributos;
using _03_01_XX_Importando_Json.Console.Modelos;
using _03_01_XX_Importando_Json.Console.Results;
using _03_01_XX_Importando_Json.Console.Servicos.Abstracoes;
using FluentResults;

namespace _03_01_XX_Importando_Json.Console.Comandos
{
    [DocComando(instrucao: "list",
      documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    public class List : IComando
    {
        private readonly IApiService clientPet;

        public List(IApiService clientPet)
        {
            this.clientPet = clientPet;
        }

        public Task<Result> ExecutarAsync()
        {
            return ListaDadosPetsDaAPIAsync();
        }

        private async Task<Result> ListaDadosPetsDaAPIAsync()
        {
            try
            {
                IEnumerable<Pet>? pets = await clientPet.ListAsync();
                return Result.Ok().WithSuccess(new SuccessWithPets(pets, "Listagem de Pet's realizada com sucesso!"));
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
            }
        }
    }
}