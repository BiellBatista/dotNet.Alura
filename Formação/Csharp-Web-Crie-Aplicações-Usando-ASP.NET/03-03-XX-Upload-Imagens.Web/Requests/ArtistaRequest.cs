﻿using System.ComponentModel.DataAnnotations;

namespace _03_03_XX_Upload_Imagens.Web.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio, string? fotoPerfil);