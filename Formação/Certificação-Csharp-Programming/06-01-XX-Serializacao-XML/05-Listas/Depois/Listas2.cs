using System;

namespace _06_01_XX_Serializacao_XML.Depois
{
    public class Listas2 : IAulaItem
    {
        public void Executar()
        {
            var loja = new LojaDeFilmes7();

            foreach (var filme in loja.Filmes)
            {
                Console.WriteLine(filme);
            }

            Console.WriteLine();

            //loja.Filmes[0].Titulo = "EVITAR";

            foreach (var filme in loja.Filmes)
            {
                Console.WriteLine(filme);
            }

            //loja.Filmes = new List<Filme>();

            //loja.Filmes.RemoveAt(0);
            //loja.Filmes.Add(new Filme(new Diretor("Zé Ninguém", 3), "Um Filme Qualquer", "2018"));
            //loja.Filmes.Clear();
            Console.WriteLine();
            foreach (var filme in loja.Filmes)
            {
                Console.WriteLine(filme);
            }
        }
    }
}
