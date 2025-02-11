﻿using System.ComponentModel.DataAnnotations;

namespace _03_XX_Filmes.API.Models;

public class Sessao
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public int FilmeId { get; set; }

    public virtual Filme Filme { get; set; }

    public int? CinemaId { get; set; }

    public virtual Cinema Cinema { get; set; }
}