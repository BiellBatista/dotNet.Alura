using _03_06_XX_ContandoTotalizandoValores.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_06_XX_ContandoTotalizandoValores
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraTunesEntities())
            {
                var query = from f in contexto.Faixas
                            where f.Album.Artista.Nome == "Led Zeppelin"
                            select f;

                var quantidade = query.Count();

                Console.WriteLine("Led Zeppelin tem {0} músicas no banco de dados.", quantidade);

                var quantidade2 = contexto.Faixas.Count(q => q.Album.Artista.Nome == "Led Zeppelin");
                Console.WriteLine("=====Consulta com sintaxe de método====");
                Console.WriteLine("Led Zeppelin tem {0} músicas no banco de dados.", quantidade2);

                var quantidade3 = contexto.Faixas.Count(); // retorna todas faixas no banco de dados
                Console.WriteLine("===Todas as músicas da base de dados: {0}", quantidade3);
                //foreach (var faixa in query)
                //    Console.WriteLine(faixa.Nome);
            }
        }
    }
}
