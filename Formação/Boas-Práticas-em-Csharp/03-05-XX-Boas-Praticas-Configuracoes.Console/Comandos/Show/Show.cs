using _03_05_XX_Boas_Praticas_Configuracoes.Console.Atributos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Results;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;
using FluentResults;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos.Show
{
    [DocComandoAttribute(instrucao: "show",
       documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        private readonly ILeitorDeArquivo<Pet> leitor;

        public Show(ILeitorDeArquivo<Pet> leitor)
        {
            this.leitor = leitor;
        }

        public Task<Result> ExecutarAsync()
        {
            try
            {
                return ExibeConteudoArquivo();
            }
            catch (Exception exception)
            {
                return Task.FromResult(Result.Fail(new Error("Importação falhou!").CausedBy(exception)));
            }
        }

        private Task<Result> ExibeConteudoArquivo()
        {
            var listaDepets = leitor.RealizaLeitura();
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithPets(listaDepets, "Exibição do arquivo realizada com sucesso!")));
        }
    }
}