namespace _03_01_XX_Web_App_Blazor.API.Response;

public record MusicaResponse(int Id, string Nome, int ArtistaId, string NomeArtista, int? anoLancamento);