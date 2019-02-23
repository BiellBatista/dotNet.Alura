using _03_03_XX_LinqToEntities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_03_XX_LinqToEntities
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsultandoComJoin();
            ConsultaComWhere();
        }

        private static void ConsultaComWhere()
        {
            using (var contexto = new AluraTunesEntities())
            {
                // filtro com linqToEntities
                // sintaxe de consulta. Uso quando o sql foi muito grande (mais complexto)
                var textoBusca = "Led";
                var query = from a in contexto.Artistas
                            where a.Nome.Contains(textoBusca)
                            select a;

                foreach (var artista in query)
                {
                    Console.WriteLine("{0}\t{1}", artista.ArtistaId, artista.Nome);
                }

                Console.WriteLine("================Consulta com outra forma de Where");
                // sintaxe de método. Uso quando o sql for pequeno (mais simples)
                var query2 = contexto.Artistas.Where(a => a.Nome.Contains(textoBusca));

                foreach (var artista in query2)
                {
                    Console.WriteLine("{0}\t{1}", artista.ArtistaId, artista.Nome);
                }
            }
        }

        private static void ConsultandoComJoin()
        {
            using (var contexto = new AluraTunesEntities())
            {
                contexto.Database.Log = Console.WriteLine; // o console recebe o log do contexto

                // definição de consulta
                var query = from g in contexto.Generos
                            select g;

                foreach (var genero in query)
                {
                    Console.WriteLine("{0}\t{1}", genero.GeneroId, genero.Nome);
                }

                Console.WriteLine("====================");

                //realizando um JOIN entre a FAIXA e o GENERO
                var faixaGenero = from g in contexto.Generos
                                  join f in contexto.Faixas on g.GeneroId equals f.GeneroId
                                  select new { f, g }; // aqui eu escrevo a query

                // aqui eu executo a query
                faixaGenero = faixaGenero.Take(10); // pegando apenas 10 itens

                foreach (var item in faixaGenero)
                {
                    Console.WriteLine("{0}\t{1}", item.f.Nome, item.g.Nome);
                }
            }
        }
    }
}
