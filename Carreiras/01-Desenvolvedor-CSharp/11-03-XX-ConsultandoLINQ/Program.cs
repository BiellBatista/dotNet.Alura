using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_03_XX_ConsultandoLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsultandoCollections();
            ConsultasLINQ();

            Console.ReadLine();
        }

        internal static void ConsultandoCollections()
        {
            //Problema: obter os nomes dos meses do ano que tem 31 dias, em maiúsculo e em ordem alfabética
            List<Mes> meses = new List<Mes>()
            {
               new Mes("Janeiro     ", 31),
               new Mes("Fevereiro   ", 28),
               new Mes("Março       ", 31),
               new Mes("Abril       ", 30),
               new Mes("Maio        ", 31),
               new Mes("Junho       ", 30),
               new Mes("Julho       ", 31),
               new Mes("Agosto      ", 31),
               new Mes("Setembro    ", 30),
               new Mes("Outubro     ", 31),
               new Mes("Novembro    ", 30),
               new Mes("Dezembro    ", 31)
            };

            meses.Sort();

            foreach (var mes in meses)
                if (mes.Dias == 31)
                    Console.WriteLine(mes.Nome.ToUpper());
        }

        internal static void ConsultasLINQ()
        {
            //Problema: obter os nomes dos meses do ano que tem 31 dias, em maiúsculo e em ordem alfabética
            List<Mes> meses = new List<Mes>()
            {
               new Mes("Janeiro     ", 31),
               new Mes("Fevereiro   ", 28),
               new Mes("Março       ", 31),
               new Mes("Abril       ", 30),
               new Mes("Maio        ", 31),
               new Mes("Junho       ", 30),
               new Mes("Julho       ", 31),
               new Mes("Agosto      ", 31),
               new Mes("Setembro    ", 30),
               new Mes("Outubro     ", 31),
               new Mes("Novembro    ", 30),
               new Mes("Dezembro    ", 31)
            };

            //LINQ = CONSULTA INTEGRADA À LINGUAGEM
            //IEnumerable<Mes> consulta = meses
            //                                .Where(m => m.Dias == 31)
            //                                .OrderBy(m => m.Nome)
            //                                .Select(m => m.Nome.ToUpper());
            //.Select(); serve para modificar o resultado de uma busca
            //deve ser string, porque estou selecionando uma string
            IEnumerable<string> consulta = meses
                                            .Where(m => m.Dias == 31)
                                            .OrderBy(m => m.Nome)
                                            .Select(m => m.Nome.ToUpper());

            foreach (var item in consulta)
                Console.WriteLine(item);
        }
    }
}
