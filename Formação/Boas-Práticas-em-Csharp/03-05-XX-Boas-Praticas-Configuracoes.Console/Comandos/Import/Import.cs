using _03_05_XX_Boas_Praticas_Configuracoes.Console.Atributos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Results;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;
using FluentResults;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos.Import
{
    [DocComandoAttribute(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando, IDepoisDaExecucao
    {
        private readonly IApiService<Pet> clientPet;

        private readonly ILeitorDeArquivo<Pet> leitor;

        public event Action<Result>? DepoisDaExecucao;

        public Import(IApiService<Pet> clientPet, ILeitorDeArquivo<Pet> leitor)
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
                var resultado = Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importação Realizada com Sucesso!"));
                DepoisDaExecucao?.Invoke(resultado);
                return resultado;
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
        }
    }
}