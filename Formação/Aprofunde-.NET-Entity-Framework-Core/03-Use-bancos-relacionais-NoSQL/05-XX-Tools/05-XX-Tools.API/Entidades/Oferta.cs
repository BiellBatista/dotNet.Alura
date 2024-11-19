﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _05_XX_Tools.API.Entidades;

public partial class Oferta
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Nome { get; set; } = null!;

    [StringLength(200)]
    public string? Descricao { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Valor { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataCriacao { get; set; }
}