using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_04_XX_Dicionarios
{
    class Program
    {
        static void Main(string[] args)
        {
            Curso csharpColecoes = new Curso("C# Colecoes", "Marcelo Oliveira");
            csharpColecoes.Adiciona(new Aula("Trabalhando com Listas", 21));
            csharpColecoes.Adiciona(new Aula("Criando uma Aula", 20));
            csharpColecoes.Adiciona(new Aula("Modelando com Coleções", 24));

            Aluno a1 = new Aluno("Vanessa Tonini", 34672);
            Aluno a2 = new Aluno("Ana Losnak", 5617);
            Aluno a3 = new Aluno("Rafael Nercessian", 17645);

            Aluno aluno5617 = csharpColecoes.BuscaMatricula(5617);

            Console.WriteLine("aluno5617" + aluno5617);

            Aluno fabio = new Aluno("Fabio Gushiken", 5617);
            csharpColecoes.SubstituiAluno(fabio);

            Console.ReadLine();
        }
    }
}
