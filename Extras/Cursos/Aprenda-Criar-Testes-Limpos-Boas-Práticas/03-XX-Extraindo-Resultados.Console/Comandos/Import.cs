using _03_XX_Extraindo_Resultados.Console.Modelos;
using _03_XX_Extraindo_Resultados.Console.Servicos;
using _03_XX_Extraindo_Resultados.Console.Util;

namespace _03_XX_Extraindo_Resultados.Console.Comandos
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
                    System.Console.WriteLine(pet);
                    await clientPet.CreatePetAsync(pet);
                }
                System.Console.WriteLine("Importação concluída!");
                return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet));
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
        }
    }
}