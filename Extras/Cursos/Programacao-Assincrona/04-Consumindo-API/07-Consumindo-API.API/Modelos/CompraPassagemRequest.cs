﻿namespace _07_Consumindo_API.API.Modelos;

public record CompraPassagemRequest
{
    public string? Origem { get; set; }
    public string? Destino { get; set; }
    public int Milhas { get; set; }
}