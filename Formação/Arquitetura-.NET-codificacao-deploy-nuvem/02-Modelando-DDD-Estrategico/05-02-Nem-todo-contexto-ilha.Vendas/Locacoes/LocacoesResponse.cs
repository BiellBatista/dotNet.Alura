namespace _05_02_Nem_todo_contexto_ilha.Vendas.Locacoes;

public record LocacaoResponse(string Id, string Status, DateTime DataInicio, DateTime DataTermino, DateTime DataPrevistaEntrega)
{
    public static LocacaoResponse From(Locacao locacao) => new(
        Id: locacao.Id.ToString(),
        Status: locacao.Status.ToString(),
        DataInicio: locacao.DataInicio,
        DataTermino: locacao.DataTermino,
        DataPrevistaEntrega: locacao.DataPrevistaEntrega
    );
}