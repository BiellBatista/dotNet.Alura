using _03_05_XX_Boas_Praticas_Configuracoes.Console.Atributos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Results;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;
using FluentResults;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos.ImportClientes;

[DocComando(instrucao: "import-clientes", documentacao: "teste")]
public class ImportClientes : IComando
{
    private readonly IApiService<Cliente> service;
    private readonly ILeitorDeArquivo<Cliente> leitor;

    public ImportClientes(IApiService<Cliente> service, ILeitorDeArquivo<Cliente> leitor)
    {
        this.service = service;
        this.leitor = leitor;
    }

    public async Task<Result> ExecutarAsync()
    {
        try
        {
            var clientes = leitor.RealizaLeitura();

            foreach (var cliente in clientes)
            {
                await service.CreateAsync(cliente);
            }

            return Result.Ok().WithSuccess(new SuccessWithClientes(clientes, "Importação realizada com sucesso!"));
        }
        catch (Exception exception)
        {
            return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
        }
    }
}