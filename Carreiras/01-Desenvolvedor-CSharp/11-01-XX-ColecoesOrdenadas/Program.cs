using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_01_XX_ColecoesOrdenadas
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadLine();
        }

        internal static void SortedList()
        {
            //vamos criar um dicionário de alunos
            IDictionary<string, Aluno> alunos = new Dictionary<string, Aluno>();
            alunos.Add("VT", new Aluno("Venssa", 34672));
            alunos.Add("AL", new Aluno("Ana", 5617));
            alunos.Add("RN", new Aluno("Rafael", 17645));
            alunos.Add("WM", new Aluno("Wanderson", 11287));

            foreach (var aluno in alunos)
                Console.WriteLine(aluno);
            //vamos remover AL
            alunos.Remove("AL");
            //vamos adicionar: MO
            alunos.Add("MO", new Aluno("Marcelo", 12345));
            Console.WriteLine();

            foreach (var aluno in alunos)
                Console.WriteLine(aluno);

            //apresentando o SortedList (Dicionário Ordenado). Ele ordena em ordem alfabética, crescente... com base na chave
            //o nome é SortedList<>(), porque as chaves são armazenadas em uma lista
            IDictionary<string, Aluno> sorted = new SortedList<string, Aluno>();
            sorted.Add("VT", new Aluno("Venssa", 34672));
            sorted.Add("AL", new Aluno("Ana", 5617));
            sorted.Add("RN", new Aluno("Rafael", 17645));
            sorted.Add("WM", new Aluno("Wanderson", 11287));

            Console.WriteLine();

            foreach (var item in sorted)
                Console.WriteLine(item);
        }
    }
}
