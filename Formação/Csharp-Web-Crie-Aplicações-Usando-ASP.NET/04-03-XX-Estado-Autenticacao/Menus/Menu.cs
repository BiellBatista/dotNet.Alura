﻿using _04_03_XX_Estado_Autenticacao.Shared.Dados.Banco;
using _04_03_XX_Estado_Autenticacao.Shared.Modelos.Modelos;

namespace _04_03_XX_Estado_Autenticacao.Menus;

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