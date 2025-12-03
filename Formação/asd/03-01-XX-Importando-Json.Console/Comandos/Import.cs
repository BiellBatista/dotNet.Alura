using _03_01_XX_Importando_Json.Console.Atributos;
using _03_01_XX_Importando_Json.Console.Results;
using _03_01_XX_Importando_Json.Console.Servicos.Abstracoes;
using FluentResults;

namespace _03_01_XX_Importando_Json.Console.Comandos
{
    [DocComando(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando
    {
        private readonly IApiService clientPet;

        private readonly ILeitorDeArquivos leitor;

        public Import(IApiService clientPet, ILeitorDeArquivos leitor)
        {
            this.clientPet = clientPet;
            this.leitor = leitor;
        }

        public async Task<Result> ExecutarAsync()
        {
            return await ImportacaoArquivoPetAsync();
        }

        private async Task<Result> ImportacaoArquivoPetAsync()
        {
            try
            {
                var listaDePet = leitor.RealizaLeitura();
                foreach (var pet in listaDePet)
                {
                    await clientPet.CreateAsync(pet);
                }
                return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importação Realizada com Sucesso!"));
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
        }
    }
}