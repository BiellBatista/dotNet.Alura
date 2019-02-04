using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_05_XX_ConvertendoEnumerandoColecoes
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.ReadLine();
        }

        internal static void CovarianciaIEnumerable()
        {
            Console.WriteLine("string para object? Sim!");
            string titulo = "meses";
            object obj = titulo; //conversão implicita
            Console.WriteLine(obj); //imprimi titulo

            Console.WriteLine("List<string> para List<object>? Não é possível!");
            IList<string> listaMeses = new List<string>()
            {
                "Janeiro", "Fevereiro", "Março",
                "Abril", "Maio", "Junho",
                "Julho", "Agosto", "Setembro",
                "Outubro", "Novembro", "Dezembro"
            };
            //a interface IList não permite essa converção implicita
            //IList<object> listaObj = listaMeses; //erro
            Console.WriteLine();

            Console.WriteLine("stirng[] para object[]? Sim!");
            string[] arrayMeses = new string[]
            {
                "Janeiro", "Fevereiro", "Março",
                "Abril", "Maio", "Junho",
                "Julho", "Agosto", "Setembro",
                "Outubro", "Novembro", "Dezembro"
            };

            object[] arrayObj = arrayMeses; //Isso aqui é uma convariância
            //Console.WriteLine(arrayObj);

            /**
             * O problema de converter um array com a convariância é que o array object deixa de ser capaz de armazenar as instância obj
             * Devo evitar sempre a convariância
             */

            foreach (var item in arrayObj)
                Console.WriteLine(item); //Imprimi o mês todo

            arrayObj[0] = "PRIMEIRO MÊS";
            Console.WriteLine(arrayObj[0]);
            Console.WriteLine();

            //arrayObj[0] = 123456; //AQUI O ERRO
            //Console.WriteLine(arrayObj[0]);
            //Console.WriteLine();

            Console.WriteLine("List<string> para IEnumerable<object>? Sim e é seguro, ao contrário da convariância de array");
            IEnumerable<object> enumObj = listaMeses; //Convariância. Posso armazenar qualquer tipo de lista
            foreach (var item in enumObj)
                Console.WriteLine(item);
            Console.WriteLine();
            //A interface IEnumerable<> não possui um indexador, pois recebe um tipo genérico out, e com isso não posso alterar seu valor

        }
    }
}
