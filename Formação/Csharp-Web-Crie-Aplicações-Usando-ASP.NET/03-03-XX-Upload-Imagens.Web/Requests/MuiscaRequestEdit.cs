﻿namespace _03_03_XX_Upload_Imagens.Web.Requests;

public record MusicaRequestEdit(int Id, string nome, int ArtistaId, int anoLancamento)
    : MusicaRequest(nome, ArtistaId, anoLancamento);