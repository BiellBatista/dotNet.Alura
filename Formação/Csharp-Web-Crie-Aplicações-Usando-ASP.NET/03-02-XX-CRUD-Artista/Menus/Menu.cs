﻿using _03_02_XX_CRUD_Artista.Shared.Dados.Banco;
using _03_02_XX_CRUD_Artista.Shared.Modelos.Modelos;

namespace _03_02_XX_CRUD_Artista.Menus;

internal class Menu
{
    public void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

    public virtual void Executar(DAL<Artista> artistaDal)
    {
        Console.Clear();
    }
}