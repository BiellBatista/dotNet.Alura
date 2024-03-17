namespace _03_05_XX_Deploy_Azure.Web.Response;
public record GeneroResponse(int Id, string Nome, string Descricao)
{
    public override string ToString()
    {
        return $"{Nome}";
    }
}