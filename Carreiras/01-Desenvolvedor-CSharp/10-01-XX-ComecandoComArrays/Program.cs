using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_01_XX_ComecandoComArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string aulaIntro = "Introdução às Coleções";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSet = "Trabalhando com Conjuntos";

            //string[] aulas = new string[]
            //{
            //    aulaIntro,
            //    aulaModelando,
            //    aulaSet
            //};

            ///---Módulo 03
            string[] aulas = new string[3];
            aulas[0] = aulaIntro;
            aulas[1] = aulaModelando;
            aulas[2] = aulaSet;

            Console.WriteLine(aulas);
            Imprimir(aulas);
            Console.WriteLine(aulas[0]);
            Console.WriteLine(aulas[aulas.Length - 1]);

            aulaIntro = "Trabalhando com Arrays";
            Imprimir(aulas);

            aulas[0] = "Trabalhando com Arrays";
            Imprimir(aulas);
            //-----

            //----Módulo 06
            Console.WriteLine($"Aula modelando está no índice {Array.IndexOf(aulas, aulaModelando)}"); //pegando a primeira ocorreção
            Console.WriteLine($"Aula modelando está no índice {Array.LastIndexOf(aulas, aulaModelando)}"); //pegando a última ocorreção 
            Array.Reverse(aulas); //invertendo a ordem
            Console.WriteLine($"{aulas}");

            Array.Resize(ref aulas, 2); //redimencionando o array de 3 para 2
            Array.Resize(ref aulas, 3); //redimencionando o array de 2 para 3. As novas possições vem com o valor nulo

            Array.Sort(aulas); //Ordenando o array em ordem alfabética. Não Consigo voltar ao estado inicial.
            //Qualquer operação realizada no meu array (referência) não poderá ser desfeita

            string[] outroArray = new string[2];
            Array.Copy(aulas, 0, outroArray, 0, 2);
            //Copiando dois conteúdo da posíção 0 do array aulas, para o array outros iniciando no 0

            string[] clone = aulas.Clone() as string[]; //copiando os valores do array aulas para o novo array clone
            //a apalavra as serve para fazer um casting

            Array.Clear(clone, 1, 2); //limpando dois dados do a partir do 1
            Console.ReadLine();
        }

        private static void Imprimir(string[] aulas)
        {
            //foreach (var aula in aulas)
            //{
            //    Console.WriteLine(aula);
            //}

            for (int i = 0; i < aulas.Length; i++)
            {
                Console.WriteLine(aulas[i]);
            }
        }
    }
}
