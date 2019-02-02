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
            Curso csharpColecoes = new Curso("C# Collections", "Marcelo Oliveira");
            csharpColecoes.Adiciona(new Aula("Trabalhando com Listas", 21));
            Imprimir(csharpColecoes.Aulas);

            //adicionando 2 aulas
            csharpColecoes.Adiciona(new Aula("Criando uma Aula", 20));
            csharpColecoes.Adiciona(new Aula("Modelando com Coleções", 19));
            Imprimir(csharpColecoes.Aulas);

            //ordenar a lista de aulas
            //csharpColecoes.Aulas.Sort(); não posso porque IList não implementa a interface IComparable

            //copiar a lista para outra lista e ordernar
            List<Aula> aulasCopiadas = new List<Aula>(csharpColecoes.Aulas);

            //ordenar a cópia
            aulasCopiadas.Sort();
            Imprimir(csharpColecoes.Aulas);

            //totalizar o tempo do curso
            Console.WriteLine(csharpColecoes.TempoTotal);
            Console.WriteLine(csharpColecoes);

            //imprimir detalhes do curso

            Console.ReadLine();
        }

        private static void Imprimir(List<Aula> aulas)
        {
            Console.Clear();

            foreach (var aula in aulas)
                Console.WriteLine($"{aula.Titulo} com duração de {aula.Tempo}");
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

        private static void ListasDeObjetos()
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
        }

        private static void Imprimir(IList<Aula> aulas)
        {
            Console.Clear();

            foreach (var aula in aulas)
                Console.WriteLine($"{aula.Titulo} com duração de {aula.Tempo}");
        }
    }
}
