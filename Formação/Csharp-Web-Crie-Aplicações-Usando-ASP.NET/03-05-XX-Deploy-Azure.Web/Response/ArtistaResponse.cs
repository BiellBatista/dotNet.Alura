namespace _03_05_XX_Deploy_Azure.Web.Response;

public record ArtistaResponse(int Id, string Nome, string Bio, string? FotoPerfil)
{
    public override string ToString()
    {
        return $"{Nome}";
    }
}