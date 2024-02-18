using _03_06_XX_Enviando_Email.Console.Atributos;
using _03_06_XX_Enviando_Email.Console.Modelos;
using _03_06_XX_Enviando_Email.Console.Results;
using _03_06_XX_Enviando_Email.Console.Servicos.Abstracoes;
using FluentResults;

namespace _03_06_XX_Enviando_Email.Console.Comandos;

[DocComando(instrucao: "import-clientes",
       documentacao: "adopet import-clientes <ARQUIVO> comando que realiza a importação do arquivo de clientes.")]
public class ImportClientes : IComando
{
    private IApiService<Cliente> apiService;
    private ILeitorDeArquivos<Cliente> leitorDeArquivo;

    public ImportClientes(IApiService<Cliente> apiService, ILeitorDeArquivos<Cliente> leitor)
    {
        this.apiService = apiService;
        leitorDeArquivo = leitor;
    }

    public async Task<Result> ExecutarAsync()
    {
        try
        {
            var lista = leitorDeArquivo.RealizaLeitura();
            foreach (var cliente in lista)
            {
                await apiService.CreateAsync(cliente);
            }
            return Result.Ok().WithSuccess(new SuccessWithClientes(lista, "Importação Realizada com Sucesso!"));
        }
        catch (Exception exception)
        {
            return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
        }
    }
}