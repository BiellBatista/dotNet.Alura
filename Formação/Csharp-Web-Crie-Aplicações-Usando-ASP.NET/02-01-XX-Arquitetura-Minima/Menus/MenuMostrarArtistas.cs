﻿using _02_01_XX_Arquitetura_Minima.Shared.Dados.Banco;
using _02_01_XX_Arquitetura_Minima.Shared.Modelos.Modelos;

namespace _02_01_XX_Arquitetura_Minima.Menus;

internal class MenuMostrarArtistas : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibindo todos os artistas registradas na nossa aplicação");

        foreach (var artista in artistaDAL.Listar())
        {
            Console.WriteLine($"Artista: {artista}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}