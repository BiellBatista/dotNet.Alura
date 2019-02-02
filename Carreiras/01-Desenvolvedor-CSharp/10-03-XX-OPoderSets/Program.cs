using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_03_XX_OPoderSets
{
    class Program
    {
        static void Main(string[] args)
        {
            //declarando curso
            Curso csharpColecoes = new Curso("C# Colecoes", "Marcelo Oliveira");

            //adicionando 3 aulas a este curso
            csharpColecoes.Adiciona(new Aula("Trabalhando com Listas", 21));
            csharpColecoes.Adiciona(new Aula("Criando uma Aula", 20));
            csharpColecoes.Adiciona(new Aula("Modelando com Coleções", 24));

            Aluno a1 = new Aluno("Vanessa Tonini", 34672);
            Aluno a2 = new Aluno("Ana Losnak", 5617);
            Aluno a3 = new Aluno("Rafael Nercessian", 17645);

            csharpColecoes.Matricula(a1);
            csharpColecoes.Matricula(a2);
            csharpColecoes.Matricula(a2);

            //imprimindo os alunos matriculados
            Console.WriteLine("Imprimindo os alunos matriculados");
            foreach (var aluno in csharpColecoes.Alunos)
            {
                Console.WriteLine(aluno);
            }

            //Imprimir: "O aluno a1 está matriculado?"
            Console.WriteLine($"O aluno a1 {a1.Nome} está matriculado?");
            //Cria um método EstaMatriculado
            Console.WriteLine(csharpColecoes.EstaMatriculado(a1)); //true

            Aluno tonini = new Aluno("Vanessa Tonini", 34672);
            //verificando se tonini está matriculada
            Console.WriteLine("Tonini está matriculada?" + csharpColecoes.EstaMatriculado(tonini));

            Console.ReadLine();
        }

        private static void Introducao()
        {
            //SETS = CONJUNTOS

            //Duas propriedades do Set
            //1. Não permite duplicidade
            //2. Os elementos não são mantidos em ordem específica

            //declarando set de alunos
            ISet<string> alunos = new HashSet<string>();
            //adicionando: vanessa, ana, rafael
            alunos.Add("Vanessa Tonini");
            alunos.Add("Ana Losnak");
            alunos.Add("Rafael Nercessian");

            //imprimindo
            //Console.WriteLine(alunos);
            Console.WriteLine(string.Join(",", alunos));
            //Imprimiu: Vanessa Tonini, Ana Losnak,Rafael Nercessian

            //adicionando: priscila, rollo, fabio
            alunos.Add("Priscila Stuani");
            alunos.Add("Rafael Rollo");
            alunos.Add("Fabio Gushiken");
            Console.WriteLine(string.Join(",", alunos));
            //Imprimiu: Vanessa Tonini, Ana Losnak,Rafael Nercessian, Priscila Stuani,Rafael Rollo, Fabio Gushiken

            //removendo aluno e adicionando outro
            alunos.Remove("Ana Losnak");
            alunos.Add("Marcelo Olibeira");
            Console.WriteLine(string.Join(",", alunos));
            //imprimiu: Vanessa Tonini,Marcelo Olibeira, Rafael Nercessian,Priscila Stuani, Rafael Rollo,Fabio Gushiken
            //repare que o Marcelo entrou no mesmo lugar que era ocupado pela ana

            //adicionando o mesmo aluno
            alunos.Add("Fabio Gushiken");
            Console.WriteLine(string.Join(",", alunos));
            //imprimiu: Vanessa Tonini,Marcelo Olibeira,Rafael Nercessian,Priscila Stuani,Rafael Rollo,Fabio Gushiken

            /**
             * Qual a vantagem do ISet<> sobre o IList<>?
             * 1. A busca em ISet<> é mais rápida, porque no IList<> é necessário percorer a lista toda para verificar se o elemento que está sendo buscado contém na lista, enquanto que no ISet<> é necessário olhar a tabela Hash (maior que uma lista), porém redireciona para o lugar ocupado do elemento. O HashSet possui uma grande escalabilidade, porém ele ocupa muita memória em comparação com uma lista.
             */

            //ordenando: sort
            //alunos.Sort(); não é possível, porque ISet<> não possui o método sort

            //copiando o ISet<> para uma IList<>
            List<string> alunosEmLista = new List<string>(alunos);
            alunosEmLista.Sort();
            Console.WriteLine(string.Join(",", alunosEmLista));
            //imprimiu: Fabio Gushiken,Marcelo Olibeira,Priscila Stuani,Rafael Nercessian,Rafael Rollo,Vanessa Tonini
        }

        private static void SetDentroModelo()
        {
            //declarando curso
            Curso csharpColecoes = new Curso("C# Colecoes", "Marcelo Oliveira");

            //adicionando 3 aulas a este curso
            csharpColecoes.Adiciona(new Aula("Trabalhando com Listas", 21));
            csharpColecoes.Adiciona(new Aula("Criando uma Aula", 20));
            csharpColecoes.Adiciona(new Aula("Modelando com Coleções", 24));

            Aluno a1 = new Aluno("Vanessa Tonini", 34672);
            Aluno a2 = new Aluno("Ana Losnak", 5617);
            Aluno a3 = new Aluno("Rafael Nercessian", 17645);

            csharpColecoes.Matricula(a1);
            csharpColecoes.Matricula(a2);
            csharpColecoes.Matricula(a2);

            //imprimindo os alunos matriculados
            Console.WriteLine("Imprimindo os alunos matriculados");
            foreach (var aluno in csharpColecoes.Alunos)
            {
                Console.WriteLine(aluno);
            }
        }
    }
}
