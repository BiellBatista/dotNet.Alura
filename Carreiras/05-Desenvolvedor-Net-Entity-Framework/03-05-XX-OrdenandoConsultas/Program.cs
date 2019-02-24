using _03_05_XX_OrdenandoConsultas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_05_XX_OrdenandoConsultas
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static void GetFaixaOrdenada(AluraTunesEntities contexto, string buscaArtista, string buscaAlbum)
        {
            /*Esta consulta é equivalente as de baixo. Esta consulta engloba todas as modificações da query
            var query = from f in contexto.Faixas
                        where f.Album.Artista.Nome.Contains(buscaArtista)
                        && (!string.IsNullOrEmpty(buscaAlbum) ? f.Album.Titulo.Contains(buscaAlbum) : true)
                        orderby f.Album.Titulo, f.Nome
                        select f;
             */

            var query = from f in contexto.Faixas
                    where f.Album.Artista.Nome.Contains(buscaArtista)
                    select f;

            if (!string.IsNullOrEmpty(buscaAlbum))
                query = query.Where(q => q.Album.Titulo.Contains(buscaAlbum));

            // ordenando por nome de album e faixa. O ThenByDescending() faz uma ordenação segundária decrecente
            query = query.OrderBy(q => q.Album.Titulo).ThenByDescending(q => q.Nome);

            foreach (var faixa in query)
                    Console.WriteLine("{0}\t{1}", faixa.Album.Titulo, faixa.Nome);
        }
    }
}

/*
 * O seguinte trecho de código é usado para consultar as notas fiscais, ordenando o resultado pelo total da nota fiscal por ordem decrescente, e em seguida pelo nome do cliente:
 * 
 * var query = from nf in contexto.NotasFiscais orderby nf.Total descending, nf.Cliente.PrimeiroNome + " " + nf.Cliente.Sobrenome select nf;
 * 
 * Reescreva a consulta acima, em forma de sintaxe de método (com expressões lambda).]
 * 
 * A consulta solicitada deveria conter os métodos OrderByDescending e ThenBy:
 * var query = contexto.NotasFiscais .OrderByDescending(nf => nf.Total) .ThenBy(nf => nf.Cliente.PrimeiroNome + " " + nf.Cliente.Sobrenome);
 */
