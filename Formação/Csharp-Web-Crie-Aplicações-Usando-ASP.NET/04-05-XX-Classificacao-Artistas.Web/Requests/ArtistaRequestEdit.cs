﻿namespace _04_05_XX_Classificacao_Artistas.Web.Requests;

public record ArtistaRequestEdit(int Id, string nome, string bio, string? fotoPerfil)
    : ArtistaRequest(nome, bio, fotoPerfil);