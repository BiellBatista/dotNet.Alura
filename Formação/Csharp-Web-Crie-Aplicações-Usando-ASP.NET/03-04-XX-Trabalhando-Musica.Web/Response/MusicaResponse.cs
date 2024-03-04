namespace _03_04_XX_Trabalhando_Musica.Web.Response;

public record MusicaResponse(int Id, string Nome, int ArtistaId, string NomeArtista, int? anoLancamento);