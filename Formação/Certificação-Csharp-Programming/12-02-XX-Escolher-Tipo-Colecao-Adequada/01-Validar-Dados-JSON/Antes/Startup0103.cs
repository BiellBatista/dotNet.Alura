using Newtonsoft.Json;
using System;

namespace _12_02_XX_Escolher_Tipo_Colecao_Adequada.Antes
{
    public class Startup0103 : IAulaItem
    {
        public void Executar()
        {
            string json = "{" +
                        "\"Diretor\":\"James Cameron\"," +
                        "\"Titulo\":\"Titanic\"," +
                        "\"DuracaoMinutos\":194" +
                    "}";

            Filme03 filme = JsonConvert.DeserializeObject<Filme03>(json);

            Console.WriteLine("Dados do objeto Filme: ");
            Console.WriteLine(filme);
            Console.ReadLine();
        }
    }

    internal class Filme03
    {
        public string Diretor { get; set; }
        public string Titulo { get; set; }
        public int DuracaoMinutos { get; set; }

        public override string ToString()
        {
            return Diretor + " - " + Titulo + " - " + DuracaoMinutos.ToString() + " minutos";
        }

        public Filme03()
        {
        }

        public Filme03(string diretor, string titulo, int duracaoMinutos)
        {
            Diretor = diretor;
            Titulo = titulo;
            DuracaoMinutos = duracaoMinutos;
        }
    }
}