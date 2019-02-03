using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_04_XX_MaisOperadoresLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] seq1 = { "janeiro", "fevereiro", "março" };
            string[] seq2 = { "fevereiro", "MARÇO", "abril" };

            Console.ReadLine();
        }

        internal static void ConsultandoSequenciasElementos()
        {
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

            //Problema: pegar o primeiro trimestre
            //o take serve para retornar os X primeiros elementos
            var consulta = meses.Take(3);
            foreach (var elemento in consulta)
                Console.WriteLine(elemento);
            Console.WriteLine();

            //Problema: pegar os meses depois do primeitro trimestre
            //skip serve para pular X elementos
            var consulta2 = meses.Skip(3);
            foreach (var elemento in consulta2)
                Console.WriteLine(elemento);
            Console.WriteLine();

            //Problema: pegar o terceiro trimestre
            //preciso pular 6 meses e depois pegar os 3 primeiros meses
            var consulta3 = meses.Skip(6).Take(3);
            foreach (var elemento in consulta3)
                Console.WriteLine(elemento);
            Console.WriteLine();

            //Problema: pegar os meses até que o mês comece com a letra 'S'
            //o TakeWhile() significa pegue enquanto.. Ele serve um predicado (pode ser um lambda)
            var consulta4 = meses.TakeWhile(m => !m.Nome.StartsWith("S"));
            foreach (var elemento in consulta4)
                Console.WriteLine(elemento);
            Console.WriteLine();

            //Problema: pular os meses até que o mês comece com a letra S
            //o SkipWhile() serve para pular até que o predicado seja atendido
            var consulta5 = meses.SkipWhile(m => !m.Nome.StartsWith("S"));
            foreach (var elemento in consulta5)
                Console.WriteLine(elemento);
            Console.WriteLine();
        }

        internal static void OperadoresConjuntosLINQ()
        {

        }
    }
}
