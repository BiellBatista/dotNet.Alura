using _03_04_XX_AssociandoFiltrandoEntidades.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_04_XX_AssociandoFiltrandoEntidades
{
    class Program
    {
        static void Main(string[] args)
        {
            Aula03();
            Aula02();
            Aula01();
        }

        private static void Aula03()
        {
            using (var contexto = new AluraTunesEntities())
            {
                string buscaArtista = "Led Zeppelin";
                var buscaAlbum = "";

                var query = from f in contexto.Faixas
                            where f.Album.Artista.Nome.Contains(buscaArtista)
                            select f;

                // caso o parametro album não esteja vázio
                if (string.IsNullOrEmpty(buscaAlbum))
                {
                    query = query.Where(q => q.Album.Titulo.Contains(buscaAlbum);
                }

                foreach (var faixa in query)
                {
                    Console.WriteLine("{0}\t{1}", faixa.Album.Titulo, faixa.Nome);
                }
            }
        }

        private static void Aula02()
        {
            using (var contexto = new AluraTunesEntities())
            {
                var textoBusca = "Led";
                Console.WriteLine("=========Select sem o Where==========");
                // consulta sem o join, usando a propriedade de navegação
                // só é possível fazer isso com o entity framework e linq
                var query2 = from alb in contexto.Albums
                             where alb.Artista.Nome.Contains(textoBusca)
                             select new
                             {
                                 NomeArtista = alb.Artista.Nome,
                                 NomeAlbum = alb.Titulo
                             };

                foreach (var item in query2)
                    Console.WriteLine("{0}\t{1}", item.NomeArtista, item.NomeAlbum);
            }
        }

        private static void Aula01()
        {
            using (var contexto = new AluraTunesEntities())
            {
                var textoBusca = "Led";
                // realizando um join para pegar o nome do artista e do album
                var query = from a in contexto.Artistas
                            join alb in contexto.Albums on a.ArtistaId equals alb.ArtistaId
                            where a.Nome.Contains(textoBusca)
                            select new { NomeArtista = a.Nome, NomeAlbum = alb.Titulo };

                foreach (var item in query)
                    Console.WriteLine("{0}\t{1}", item.NomeArtista, item.NomeAlbum);
            }
        }
    }
}
