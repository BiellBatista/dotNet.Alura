﻿namespace _03_02_XX_CRUD_Artista.Web.Requests;

public record MusicaRequestEdit(int Id, string nome, int ArtistaId, int anoLancamento)
    : MusicaRequest(nome, ArtistaId, anoLancamento);