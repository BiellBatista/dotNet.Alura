using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_XX_XX_ListTLambdaLinq.Extensoes
{
    //uma classe genérica para que o método de extensão seja genérico
    public static class ListExtensoes<T>
    {
        /**
         * Método de extensão serve para criar um novo método estátio em uma classe já definida, é necessário colocar this no parametro que irá receber a classe.
         * Ele só serve para uma lista de inteiro
         **/
        public static void AdicionarVarios(this List<T> listaDeInteiros, params T[] itens)
        {
            foreach (T item in itens)
                listaDeInteiros.Add(item);
        }
    }
}
