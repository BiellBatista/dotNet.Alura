﻿namespace _03_05_XX_Deploy_Azure.Web.Response;

public record MusicaResponse(int Id, string Nome, int ArtistaId, string NomeArtista, int? anoLancamento);