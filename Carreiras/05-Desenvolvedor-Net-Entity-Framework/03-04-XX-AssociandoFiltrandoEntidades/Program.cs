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
    }
}
