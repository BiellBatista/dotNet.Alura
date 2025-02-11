﻿using System;
using System.Collections.Generic;

namespace _09_05_XX_Compilacao_Modo_Debug_Release.Antes
{
    public class Startup02 : IAulaItem
    {
        private const string DatabaseServer = "(LocalDB)\\MSSQLLocalDB";
        private const string MasterDatabase = "master";
        private const string DatabaseName = "Cinema";

        public async void Executar()
        {
            var cinemaDB = new CinemaDB02(DatabaseServer, MasterDatabase, DatabaseName);

            await cinemaDB.CriarBancoDeDadosAsync();

            IList<Filme02> filmes = await cinemaDB.GetFilmes();

            foreach (var filme in filmes)
            {
                Console.WriteLine("Diretor: {0} Titulo: {1}", filme.Diretor, filme.Titulo);
            }

            Console.ReadKey();
        }
    }
}