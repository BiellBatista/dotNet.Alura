using _03_06_XX_Enviando_Email.Console.Atributos;
using _03_06_XX_Enviando_Email.Console.Modelos;
using _03_06_XX_Enviando_Email.Console.Results;
using _03_06_XX_Enviando_Email.Console.Servicos.Abstracoes;
using FluentResults;

namespace _03_06_XX_Enviando_Email.Console.Comandos
{
    [DocComandoAttribute(instrucao: "list",
      documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    public class List : IComando
    {
        private readonly IApiService<Pet> clientPet;

        public List(IApiService<Pet> clientPet)
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