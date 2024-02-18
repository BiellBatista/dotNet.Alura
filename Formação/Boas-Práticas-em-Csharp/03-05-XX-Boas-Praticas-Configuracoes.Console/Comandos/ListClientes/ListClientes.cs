using _03_05_XX_Boas_Praticas_Configuracoes.Console.Atributos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Results;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;
using FluentResults;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos.ListClientes;

[DocComando(
    instrucao: "list-clientes",
    documentacao: "adopet list-clientes comando que exibe no terminal clientes cadastrados na base de dados da AdoPet.")]
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
            var lista = await service.ListAsync();
            return Result.Ok().WithSuccess(new SuccessWithClientes(lista, "Listagem concluída com sucesso!"));
        }
        catch (Exception e)
        {
            return Result.Fail(new Error("Listagem de clientes falhou").CausedBy(e));
        }
    }
}