﻿namespace _06_XX_EF_MongoDB.API.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? Cep { get; set; }
}