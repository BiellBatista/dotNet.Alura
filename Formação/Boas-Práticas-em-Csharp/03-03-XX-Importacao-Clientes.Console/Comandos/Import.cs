using _03_03_XX_Importacao_Clientes.Console.Atributos;
using _03_03_XX_Importacao_Clientes.Console.Modelos;
using _03_03_XX_Importacao_Clientes.Console.Results;
using _03_03_XX_Importacao_Clientes.Console.Servicos.Abstracoes;
using FluentResults;

namespace _03_03_XX_Importacao_Clientes.Console.Comandos
{
    [DocComando(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando
    {
        private readonly IApiService<Pet> clientPet;

        private readonly ILeitorDeArquivos<Pet> leitor;

        public Import(IApiService<Pet> clientPet, ILeitorDeArquivos<Pet> leitor)
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