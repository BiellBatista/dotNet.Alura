using System;
using System.Collections.Generic;

namespace _09_07_XX_Gravando_Mensagens_Event_Log.Antes
{
    public class Startup03 : IAulaItem
    {
        private const string DatabaseServer = "(LocalDB)\\MSSQLLocalDB";
        private const string MasterDatabase = "master";
        private const string DatabaseName = "Cinema";

        public async void Executar()
        {
            var cinemaDB = new CinemaDB03(DatabaseServer, MasterDatabase, DatabaseName);

            await cinemaDB.CriarBancoDeDadosAsync();

            IList<Filme03> filmes = await cinemaDB.GetFilmes();

            foreach (var filme in filmes)
            {
                Console.WriteLine("Diretor: {0} Titulo: {1}", filme.Diretor, filme.Titulo);
            }

            Console.ReadKey();
        }
    }
}