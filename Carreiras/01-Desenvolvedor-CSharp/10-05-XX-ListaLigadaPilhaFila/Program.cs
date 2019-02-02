using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_05_XX_ListaLigadaPilhaFila
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadLine();
        }

        private static void LinkedList()
        {
            //Imagine uma lista de frutas
            List<string> frutas = new List<string>
            {
                "abacate", "banana", "caqui", "damasco", "figo"
            };
            //Vamos imprimir essa lista
            foreach (var fruta in frutas)
            {
                Console.WriteLine(fruta);
            }

            //instanciando uma lista ligada
            LinkedList<string> dias = new LinkedList<string>();
            //adicionando um dia qualquer: quarta
            var d4 = dias.AddFirst("quarta"); //adicionando o primeiro elemento

            //cada elemento é um nó: LinkedListNode<T>
            //para acessar o valor do nó, basta fazer
            Console.WriteLine("d4.Value: " + d4.Value); //quarta

            //Podemos adicionar de 4 formas:
            //1. Como o primeiro nó
            //2. Como últmo nó
            //3. Antes de um nó conhecido
            //4. Depois de um nó conhecido

            //Vamos adicionar segunda, antes de quarta:
            var d2 = dias.AddBefore(d4, "segunda");
            //agora d2 e d4 estão ligados!
            //Para acessar um nó antes ou depois de um certo nó, basta
            //1. d2.Next é igual a d4
            //2. d4.Previous é igual a d2

            //adicionando terça depois de segunda
            var d3 = dias.AddAfter(d2, "terça");

            //adicionando sexta depois da quarta
            var d6 = dias.AddAfter(d4, "sexta");

            //sábado depois da sexta
            var d7 = dias.AddAfter(d6, "sábado");

            //quinta antes da sexta
            var d5 = dias.AddBefore(d6, "quinta");

            //domingo antes da segunda
            var d1 = dias.AddBefore(d2, "domingo");

            //agora vamos imprimir a lista ligada
            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }
            //LinkedList NÃO DÁ suporte ao acesso de índice: dias[0]
            //a lista ligada não permite o acesso com [], com isso não posso usar um for
            var quarta = dias.Find("quarta"); //não é eficiente

            //Para removermos um elemento, podemos tanto
            //remover pelo valor quanto pela
            //referência do LinkedListNode
            dias.Remove("qurta"); //removendo com base no valor
            dias.Remove(d5); //removendo com base na referência
        }
    }
}
