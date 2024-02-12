using _03_04_XX_Entendendo_OCP.Console.Atributos;
using _03_04_XX_Entendendo_OCP.Console.Modelos;
using _03_04_XX_Entendendo_OCP.Console.Results;
using _03_04_XX_Entendendo_OCP.Console.Servicos.Abstracoes;
using FluentResults;

namespace _03_04_XX_Entendendo_OCP.Console.Comandos
{
    [DocComandoAttribute(instrucao: "show",
       documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        private readonly ILeitorDeArquivos<Pet> leitor;

        public Show(ILeitorDeArquivos<Pet> leitor)
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
                return Task.FromResult(Result.Fail(new Error("Exibição do arquivo falhou!").CausedBy(exception)));
            }
        }

        private Task<Result> ExibeConteudoArquivo()
        {
            var listaDepets = leitor.RealizaLeitura();
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithPets(listaDepets, "Exibição do arquivo realizada com sucesso!")));
        }
    }
}