namespace _03_04_XX_Trabalhando_Musica.Web.Response;

public record ArtistaResponse(int Id, string Nome, string Bio, string? FotoPerfil)
{
    public override string ToString()
    {
        return $"{Nome}";
    }
}