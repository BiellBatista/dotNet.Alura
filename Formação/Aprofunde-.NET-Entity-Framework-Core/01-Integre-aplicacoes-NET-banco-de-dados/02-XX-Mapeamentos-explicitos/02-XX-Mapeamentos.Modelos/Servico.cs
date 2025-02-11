﻿namespace _02_XX_Mapeamentos_explicitos.Modelos;

public class Servico
{
    public Servico()
    {
    }

    public Servico(Guid id, string? titulo, string? descricao, StatusServico status)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        Status = status;
    }

    public Guid Id { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public StatusServico Status { get; set; }
}