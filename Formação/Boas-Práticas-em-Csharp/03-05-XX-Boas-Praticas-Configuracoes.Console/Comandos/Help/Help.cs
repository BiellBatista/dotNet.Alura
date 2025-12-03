using _03_05_XX_Boas_Praticas_Configuracoes.Console.Atributos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Results;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Util;
using FluentResults;
using System.Reflection;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos.Help
{
    [DocComando(instrucao: "help",
     documentacao: "adopet help comando que exibe informações da ajuda. \n" +
        "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
    public class Help : IComando
    {
        private Dictionary<string, DocComandoAttribute> docs;
        private string? comando;

        public Help(string? comando)
        {
            docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly());
            this.comando = comando;
        }

        public Task<Result> ExecutarAsync()
        {
            try
            {
                return Task.FromResult(Result.Ok()
                  .WithSuccess(new SuccessWithDocs(GerarDocumentacao())));
            }
            catch (Exception exception)
            {
                return Task.FromResult(Result.Fail(new Error("Exibição da documentação falhou!").CausedBy(exception)));
            }
        }

        private IEnumerable<string> GerarDocumentacao()
        {
            List<string> resultado = new List<string>();
            // se não passou mais nenhum argumento mostra help de todos os comandos
            if (comando is null)
            {
                foreach (var doc in docs.Values)
                {
                    resultado.Add(doc.Documentacao);
                }
            }
            // exibe o help daquele comando específico
            else
            {
                if (docs.ContainsKey(comando))
                {
                    var comando = docs[this.comando];
                    resultado.Add(comando.Documentacao);
                }
                else
                {
                    resultado.Add("Comando não encontrado!");
                    throw new ArgumentException();
                }
            }
            return resultado;
        }
    }
}