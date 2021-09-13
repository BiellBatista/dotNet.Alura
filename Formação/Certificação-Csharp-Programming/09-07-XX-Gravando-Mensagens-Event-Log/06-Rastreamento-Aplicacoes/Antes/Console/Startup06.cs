using System;
using System.Collections.Generic;

namespace _09_07_XX_Gravando_Mensagens_Event_Log.Antes
{
    public class Startup06 : IAulaItem
    {
        private const string DatabaseServer = "(LocalDB)\\MSSQLLocalDB";
        private const string MasterDatabase = "master";
        private const string DatabaseName = "Cinema";

        public async void Executar()
        {
            var cinemaDB = new CinemaDB06(DatabaseServer, MasterDatabase, DatabaseName);

            await cinemaDB.CriarBancoDeDadosAsync();

            IList<Filme06> filmes = await cinemaDB.GetFilmes();

            foreach (var filme in filmes)
            {
                Console.WriteLine("Diretor: {0} Titulo: {1}", filme.Diretor, filme.Titulo);
            }

            Console.ReadKey();
        }
    }
}