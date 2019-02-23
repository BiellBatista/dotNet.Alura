using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _03_02_XX_LinqXML
{
    class Program
    {
        static void Main(string[] args)
        {
            // acessando XML com LINQ
            XElement root = XElement.Load(@"Data\AluraTunes.xml");

            // puxando dados de generos do XML
            // acessando o Elemento do "Generos" e pegando seus intens "Genero"
            var queryXML = from g in root.Element("Generos").Elements("Genero") select g;

            foreach (var genero in queryXML)
            {
                // genero é um nó do XML
                                               // acesando o nó "GeneroId", do XML, e recuperando o seu Valor
                                                                              // acesando o nó "Nome", do XML, e recuperando o seu Valor         
                Console.WriteLine("{0}\t{1}", genero.Element("GeneroId").Value, genero.Element("Nome").Value);
            }

            // realizando um join
            var query = from g in root.Element("Generos").Elements("Genero")
                        join m in root.Element("Musicas").Elements("Musica") on g.Element("GeneroId").Value equals m.Element("GeneroId").Value
                        select new { Musica = m.Element("Nome").Value, Genero = g.Element("Nome").Value };

            Console.WriteLine("JOIN com XML");
            foreach (var generoMusica in query)
            {
                Console.WriteLine("{0}\t{1}", generoMusica.Musica, generoMusica.Genero);
            }

            Console.WriteLine("Resposta do Exercício 06");
            var queryExe = from m in root.Element("Musicas").Elements("Musica")
                           join g in root.Element("Generos").Elements("Genero")
                            on m.Element("GeneroId").Value equals g.Element("GeneroId").Value
                           select new { MusicaId = m.Element("MusicaId").Value, Nome = m.Element("Nome").Value, Genero = g.Element("Nome").Value };

            foreach (var musica in queryExe)
                Console.WriteLine("{0}\t{1}\t{2}", musica.MusicaId, musica.Nome, musica.Genero);
        }
    }
}
