namespace _03_02_XX_CRUD_Artista.Web.Response;

public record MusicaResponse(int Id, string Nome, int ArtistaId, string NomeArtista, int? anoLancamento);