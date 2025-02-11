﻿using _03_06_XX_ContandoTotalizandoValores.Data;
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
            Contagem();
            Sum();
            GroupBy();
        }

        private static void Sum()
        {
            using (var contexto = new AluraTunesEntities())
            {
                var query = from inf in contexto.ItemNotaFiscals
                            where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                            select new
                            {
                                TotalDoItem = inf.Quantidade * inf.PrecoUnitario
                            };

                //foreach (var inf in query)
                //    Console.WriteLine("{0}", inf.TotalDoItem);
                //    //Console.WriteLine("{0}\t{1}\t{2}", inf.Faixa.Nome, inf.Quantidade, inf.PrecoUnitario);

                var totalDoArtista = query.Sum(q => q.TotalDoItem);
                Console.WriteLine("Total do artista: R${0}", totalDoArtista);
            }
        }

        private static void GroupBy()
        {
            using (var contexto = new AluraTunesEntities())
            {
                // palavra let, permite criar variável que será usadada, internamente, em uma consulta linq
                var query = from inf in contexto.ItemNotaFiscals
                            where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                            group inf by inf.Faixa.Album into agrupado
                            let vendasPorAlbum = agrupado.Sum(a => a.Quantidade * a.PrecoUnitario)
                            orderby vendasPorAlbum descending
                            // quando eu uso o group by, o inf é substituido pelo agrupado
                            //a sintaxe do group by é: group "objeto do from" by "valor que será agrupado, ou objeto" into "novo objeto para a query
                            select new
                            {
                                TituloDoAlbum = agrupado.Key.Titulo,
                                TotalPorAlbum = vendasPorAlbum
                            };
                // o agrupado.Key é o objeto que está sendo agrupado, no meu caso o "Album", e partir dele eu posso acessar suas propriedades

                foreach (var agrupado in query)
                    Console.WriteLine("{0}\t{1}",
                        agrupado.TituloDoAlbum.PadRight(40),
                        agrupado.TotalPorAlbum
                        );
                //Console.WriteLine("{0}\t{1}\t{2}\t{3}", inf.Faixa.Album.Titulo.PadRight(40), inf.Faixa.Nome.PadRight(25), inf.Quantidade, inf.PrecoUnitario);
            }
        }

        private static void Contagem()
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

/*
 * Considere a consulta abaixo, para trazer uma lista de artistas e respectivos álbuns:
 * var artistaEalbumQuery =
from alb in contexto.Albums
select new
{
    Artista = alb.Artista.Nome,
    Titulo = alb.Titulo
};
foreach (var item in artistaEalbumQuery)
{
    Console.WriteLine("{0}\t{1}", item.Artista, item.Titulo);
}

 *Desenvolva uma nova consulta com base nessa, para trazer desta vez o nome do artista e a quantidade de álbuns dele.
 * 
 * Para implementar essa nova consulta, é necessário utilizar a cláusula group ... by ... into, para agrupar os álbuns por artista, e em seguida utilizar a variável de agrupamento (aqui chamada de agrupado) para extrair tanto o nome do artista quanto a contagem de álbuns por artista:
 * 
 * var artistaEqtdeAlbuns =
from alb in contexto.Albums
group alb by alb.Artista into agrupado
select new
{
    Artista = agrupado.Key.Nome,
    QuantidadeAlbuns = agrupado.Count()
};
foreach (var item in artistaEqtdeAlbuns)
{
    Console.WriteLine("{0}\t{1}", item.Artista, item.QuantidadeAlbuns);
}
 */
