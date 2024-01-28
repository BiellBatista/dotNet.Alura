using _01_XX_Declarando_Dependencias.Console.Modelos;
using _01_XX_Declarando_Dependencias.Console.Servicos;
using _01_XX_Declarando_Dependencias.Console.Util;

namespace _01_XX_Declarando_Dependencias.Console.Comandos
{
    [DocComando(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    internal class Import : IComando
    {
        private readonly HttpClientPet clientPet;

        public Import(HttpClientPet clientPet)
        {
            this.clientPet = clientPet;
        }

        public async Task ExecutarAsync(string[] args)
        {
            await ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
        }

        private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
        {
            var leitor = new LeitorDeArquivo();
            List<Pet> listaDePet = leitor.RealizaLeitura(caminhoDoArquivoDeImportacao);
            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);
                try
                {
                    await clientPet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }
    }
}