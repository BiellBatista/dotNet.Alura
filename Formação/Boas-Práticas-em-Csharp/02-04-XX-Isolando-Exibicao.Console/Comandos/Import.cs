using _02_04_XX_Isolando_Exibicao.Console.Modelos;
using _02_04_XX_Isolando_Exibicao.Console.Servicos;
using _02_04_XX_Isolando_Exibicao.Console.Util;
using FluentResults;

namespace _02_04_XX_Isolando_Exibicao.Console.Comandos
{
    [DocComando(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando
    {
        private readonly HttpClientPet clientPet;

        private readonly LeitorDeArquivo leitor;

        public Import(HttpClientPet clientPet, LeitorDeArquivo leitor)
        {
            this.clientPet = clientPet;
            this.leitor = leitor;
        }

        public async Task<Result> ExecutarAsync(string[] args)
        {
            return await ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
        }

        private async Task<Result> ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
        {
            try
            {
                List<Pet> listaDePet = leitor.RealizaLeitura();
                foreach (var pet in listaDePet)
                {
                    await clientPet.CreatePetAsync(pet);
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