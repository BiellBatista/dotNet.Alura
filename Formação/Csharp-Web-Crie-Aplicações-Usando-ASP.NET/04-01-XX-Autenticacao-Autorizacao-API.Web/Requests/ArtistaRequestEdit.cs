﻿namespace _04_01_XX_Autenticacao_Autorizacao_API.Web.Requests;

public record ArtistaRequestEdit(int Id, string nome, string bio, string? fotoPerfil)
    : ArtistaRequest(nome, bio, fotoPerfil);