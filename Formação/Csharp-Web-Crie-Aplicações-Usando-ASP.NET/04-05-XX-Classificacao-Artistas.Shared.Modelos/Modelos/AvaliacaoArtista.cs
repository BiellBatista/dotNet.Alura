﻿namespace _04_05_XX_Classificacao_Artistas.Shared.Modelos.Modelos;

public class AvaliacaoArtista
{
    public int ArtistaId { get; set; }
    public virtual Artista? Artista { get; set; }
    public int PessoaId { get; set; }
    public int Nota { get; set; }
}