using _03_04_XX_Entendendo_OCP.Console.Atributos;
using _03_04_XX_Entendendo_OCP.Console.Modelos;
using _03_04_XX_Entendendo_OCP.Console.Results;
using _03_04_XX_Entendendo_OCP.Console.Servicos.Abstracoes;
using FluentResults;

namespace _03_04_XX_Entendendo_OCP.Console.Comandos;

[DocComando(instrucao: "list-clientes",
    documentacao: "adopet list-clientes comando que exibe no" +
    " terminal o conteúdo de clientes na base de dados da AdoPet.")]
public class ListClientes : IComando
{
    private readonly IApiService<Cliente> service;

    public ListClientes(IApiService<Cliente> service)
    {
        this.service = service;
    }

    public async Task<Result> ExecutarAsync()
    {
        try
        {
            IEnumerable<Cliente>? clientes = await service.ListAsync();
            return Result.Ok().WithSuccess(new SuccessWithClientes(clientes, "Listagem de Clientess realizada com sucesso!"));
        }
        catch (Exception exception)
        {
            return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
        }
    }
}