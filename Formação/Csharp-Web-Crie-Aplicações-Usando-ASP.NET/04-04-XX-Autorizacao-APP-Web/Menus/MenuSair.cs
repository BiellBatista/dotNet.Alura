﻿using _04_04_XX_Autorizacao_APP_Web.Shared.Dados.Banco;
using _04_04_XX_Autorizacao_APP_Web.Shared.Modelos.Modelos;

namespace _04_04_XX_Autorizacao_APP_Web.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}