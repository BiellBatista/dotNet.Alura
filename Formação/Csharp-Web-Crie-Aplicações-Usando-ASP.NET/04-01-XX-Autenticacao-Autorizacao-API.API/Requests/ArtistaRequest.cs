﻿using System.ComponentModel.DataAnnotations;

namespace _04_01_XX_Autenticacao_Autorizacao_API.API.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio, string? fotoPerfil);