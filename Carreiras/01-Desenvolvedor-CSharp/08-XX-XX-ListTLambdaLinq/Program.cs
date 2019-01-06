using _08_XX_XX_ListTLambdaLinq.Extensoes;
using System;
using System.Collections.Generic;

namespace _08_XX_XX_ListTLambdaLinq
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> idades = new List<int>();

            idades.Add(1);
            idades.Add(5);
            idades.Add(14);
            idades.Add(25);
            idades.Add(38);
            idades.Add(61);

            //Aqui estou usando o método de extensão, posso usar ele invocando a classe que ele foi definido
            ListExtensoes.AdicionarVarios(idades, 1, 5687, 1987, 1567, 987);
            //ou posso usar ele colocando o objeto (o primeiro parametro com this)
            //o ícone de um método de extensão é o cubo com uma seta pra baixo
            idades.AdicionarVarios(1, 5687, 1987, 1567, 987);
            //idades.Remove(5);

            for (int i = 0; i < idades.Count; i++)
                Console.WriteLine(idades[i]);
            Console.ReadLine();
        }
    }
}
