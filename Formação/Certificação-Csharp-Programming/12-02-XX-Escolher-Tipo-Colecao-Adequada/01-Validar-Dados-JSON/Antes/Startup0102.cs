using System;

namespace _12_02_XX_Escolher_Tipo_Colecao_Adequada.Antes
{
    public class Startup0102 : IAulaItem
    {
        public void Executar()
        {
            //Filme02 filme = new Filme02(diretor: "Tim Burton", titulo: "A Fantástica Fábrica de Chocolate", duracaoMinutos: 115);
            //XmlSerializer serializador = new XmlSerializer(typeof(Filme));
            //TextWriter writer = new StringWriter();

            //serializador.Serialize(textWriter: writer, o: filme);
            //writer.Close();

            //string xml = writer.ToString();

            //Console.WriteLine();
            //Console.WriteLine("Versão XML:");
            //Console.WriteLine(xml);

            //TextReader reader = new StringReader(xml);

            //Filme02 filme2 = serializador.Deserialize(reader) as Filme;

            //Console.WriteLine();
            //Console.WriteLine("Dados do objeto Filme: ");
            //Console.WriteLine(filme2);
            Console.ReadLine();
        }
    }

    internal class Filme02
    {
        public string Diretor { get; set; }
        public string Titulo { get; set; }
        public int DuracaoMinutos { get; set; }

        public override string ToString()
        {
            return Diretor + " - " + Titulo + " - " + DuracaoMinutos.ToString() + " minutos";
        }

        public Filme02()
        {
        }

        public Filme02(string diretor, string titulo, int duracaoMinutos)
        {
            Diretor = diretor;
            Titulo = titulo;
            DuracaoMinutos = duracaoMinutos;
        }
    }
}