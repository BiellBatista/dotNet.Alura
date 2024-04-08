namespace _04_05_XX_Classificacao_Artistas.API.Response;

public record ArtistaResponse(int Id, string Nome, string Bio, string? FotoPerfil)
{
    public double? Classificacao { get; set; }
};