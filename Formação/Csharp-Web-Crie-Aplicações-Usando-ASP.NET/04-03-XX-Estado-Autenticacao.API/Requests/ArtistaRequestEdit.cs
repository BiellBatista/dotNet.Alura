﻿namespace _04_03_XX_Estado_Autenticacao.API.Requests;

public record ArtistaRequestEdit(int Id, string nome, string bio, string? fotoPerfil)
    : ArtistaRequest(nome, bio, fotoPerfil);