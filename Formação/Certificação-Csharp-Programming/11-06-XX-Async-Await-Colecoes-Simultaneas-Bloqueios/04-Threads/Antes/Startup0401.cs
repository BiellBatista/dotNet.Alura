using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace _11_06_XX_Async_Await_Colecoes_Simultaneas_Bloqueios.Antes
{
    public class Filme04
    {
        public string Titulo { get; set; }
        public decimal Faturamento { get; set; }
        public decimal Orcamento { get; set; }
        public string Distribuidor { get; set; }
        public string Genero { get; set; }
        public string Diretor { get; set; }
        public decimal Lucro { get; set; }
        public decimal LucroPorcentagem { get; set; }

        public int CompareTo(object obj)
        {
            Filme04 outro = obj as Filme04;

            return Titulo.CompareTo(outro.Titulo);
        }
    }

    public class Startup0401 : IAulaItem
    {
        public void Executar()
        {
            //TAREFA 1: Executar o código
            //TAREFA 2: Testar com nome de arquivo inexistente
            //TAREFA 3: Ler o conteúdo do arquivo de forma ASSÍNCRONA
            //TAREFA 4: Testar novamente com nome de arquivo inexistente

            try
            {
                Executar02("filmes.json");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            Console.ReadLine();
        }

        private void Executar02(string nomeArquivo)
        {
            string json = LerArquivoJson(nomeArquivo);
            IEnumerable<Filme> filmes = JsonConvert.DeserializeObject<IEnumerable<Filme>>(json);

            GeraRelatorio(filmes);
        }

        private string LerArquivoJson(string nomeArquivo)
        {
            return File.ReadAllText(nomeArquivo);
        }

        private static void GeraRelatorio(IEnumerable<Filme> filmes)
        {
            Console.WriteLine("{0,-30} {1,20:N2} {2,20:N2} {3,20:N2} {4,10:P}",
                    "Item",
                    "Faturamento",
                    "Orcamento",
                    "Lucro",
                    "% Lucro");
            Console.WriteLine("{0,-30} {1,20:N2} {2,20:N2} {3,20:N2} {4,10:P}",
                    new string('=', 30),
                    new string('=', 20),
                    new string('=', 20),
                    new string('=', 20),
                    new string('=', 10));

            foreach (var item in filmes)
            {
                Console.WriteLine("{0,-30} {1,20:N2} {2,20:N2} {3,20:N2} {4,10:P}",
                    item.Titulo,
                    item.Faturamento,
                    item.Orcamento,
                    item.Lucro,
                    item.LucroPorcentagem);
            }

            Console.WriteLine();
        }
    }
}