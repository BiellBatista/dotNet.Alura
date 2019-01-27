using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_02_XX_ListaAColeçãoFlexível
{
    class Program
    {
        static void Main(string[] args)
        {
            var aulaIntro = new Aula("Introdução às Coleções", 20);
            var aulaModelando = new Aula("Modelando a Classe Aula", 18);
            var aulaSet = new Aula("Trabalhando com Conjuntos", 16);

            List<Aula> aulas = new List<Aula>();
            aulas.Add(aulaIntro);
            aulas.Add(aulaModelando);
            aulas.Add(aulaSet);
            //aulas.Add("Conclusão");

            Imprimir(aulas);

            aulas.Sort(); //ordena a lista
            Imprimir(aulas);
            aulas.Sort((este, outro) => este.Tempo.CompareTo(outro.Tempo)); //ordenando pelo tempo
            Imprimir(aulas);
            Console.ReadLine();
        }

        private static void Imprimir(List<Aula> aulas)
        {
            Console.Clear();

            foreach (var aula in aulas)
                Console.WriteLine(aula.Titulo);
        }

        private static void Imprimir(List<string> aulas)
        {
            //foreach (var aula in aulas)
            //    Console.WriteLine(aula);

            //for (int i = 0; i < aulas.Count; i++)
            //    Console.WriteLine(aulas[i]);
            //para cada "aula" execute "=>" o código "{}"
            aulas.ForEach(aula =>
            {
                Console.WriteLine(aula);
            });
            //equivalente ao for e foreach
        }

        private static void OperacaoComLista()
        {
            string aulaIntro = "Introdução às Coleções";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSet = "Trabalhando com Conjuntos";

            //List<string> aulas = new List<string>
            //{
            //    aulaIntro,
            //    aulaModelando,
            //    aulaSet
            //}; //declarando lista com valores default

            List<string> aulas = new List<string>();
            aulas.Add(aulaIntro);
            aulas.Add(aulaModelando);
            aulas.Add(aulaSet);

            Imprimir(aulas);

            Console.WriteLine("A primeira aula é " + aulas[0]);
            Console.WriteLine("A primeira aula é " + aulas.First()); //pegando o primeiro elemento
            Console.WriteLine("A primeira aula é " + aulas.Last()); //pegando o último elemento
            Console.WriteLine("A última aula é " + aulas[aulas.Count - 1]);

            aulas[0] = "Trabalhando com Listas";

            Imprimir(aulas);

            Console.WriteLine($"A primeira aula 'Trabalhando' é: {aulas.First(aula => aula.Contains("Trabalhando"))}"); //usando lambda para busca
            Console.WriteLine($"A última aula 'Trabalhando' é: {aulas.Last(aula => aula.Contains("Trabalhando"))}");
            aulas.Reverse(); //invertendo a lista
            aulas.RemoveAt(aulas.Count - 1); //removendo o último índice

            //pegando um intervalo de elementos da lista (inicío, fim)
            List<string> copia = aulas.GetRange(aulas.Count - 2, aulas.Count - 1);
            List<string> clone = new List<string>(aulas);

            //removendo um intervalo de elementos da lista (inicío, fim)
            clone.RemoveRange(clone.Count - 2, clone.Count - 1);
        }

        class Aula : IComparable
        {
            public string Titulo { get; set; }
            public int Tempo { get; set; }

            public Aula(string titulo, int tempo)
            {
                Titulo = titulo;
                Tempo = tempo;
            }

            public override string ToString()
            {
                return $"O título da aula é {Titulo} e possui a duração de {Tempo}";
            }

            public int CompareTo(object obj)
            {
                var tmp = obj as Aula;

                return this.Titulo.CompareTo(tmp.Titulo);
            }
        }
    }
}
