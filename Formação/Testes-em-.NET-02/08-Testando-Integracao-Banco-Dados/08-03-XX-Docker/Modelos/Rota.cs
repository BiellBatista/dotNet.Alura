﻿using _08_03_XX_Docker.Validador;

namespace _08_03_XX_Docker.Modelos;

public class Rota : Valida
{
    public int Id { get; set; }
    public string Origem { get; set; }
    public string Destino { get; set; }

    public ICollection<OfertaViagem> OfertasViagem { get; set; }

    public Rota(string origem, string destino)
    {
        Origem = origem;
        Destino = destino;
    }

    protected override void Validar()
    {
        if (Origem is null || Origem.Equals(string.Empty))
        {
            Erros.RegistrarErro("A rota não pode possuir uma origem nula ou vazia.");
        }
        else if (Destino is null || Destino.Equals(string.Empty))
        {
            Erros.RegistrarErro("A rota não pode possuir um destino nulo ou vazio.");
        }
    }
}