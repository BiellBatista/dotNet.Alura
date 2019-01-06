using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_XX_XX_ListTLambdaLinq.Extensoes
{
    //uma classe genérica para que o método de extensão seja genérico
    //Não posos colocar um método de exntesão dentro de uma classe genérica, porque o compilador não saberá qual tipo de classe o método é extendido 
    //public static class ListExtensoes<T>
    public static class ListExtensoes
    {
        /**
         * Método de extensão serve para criar um novo método estátio em uma classe já definida, é necessário colocar this no parametro que irá receber a classe.
         * Ele só serve para uma lista de inteiro.
         **/
         //Estou criando um método genérico extensivel. POsos criar um método de extensão sem ser genérico
        public static void AdicionarVarios<T>(this List<T> listaDeInteiros, params T[] itens)
        {
            foreach (T item in itens)
                listaDeInteiros.Add(item);
        }
    }
}
