﻿namespace _03_03_XX_Upload_Imagens.API.Requests;

public record ArtistaRequestEdit(int Id, string nome, string bio, string? fotoPerfil)
    : ArtistaRequest(nome, bio, fotoPerfil);