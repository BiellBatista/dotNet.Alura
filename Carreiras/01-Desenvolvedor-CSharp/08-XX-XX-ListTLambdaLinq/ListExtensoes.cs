using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_XX_XX_ListTLambdaLinq
{
    public static class ListExtensoes
    {
        /**
         * Método de extensão serve para criar um novo método estátio em uma classe já definida, é necessário colocar this no parametro que irá receber a classe.
         * Ele só serve para uma lista de inteiro
         **/
        public static void AdicionarVarios(this List<int> listaDeInteiros, params int[] itens)
        {
            foreach (int item in itens)
                listaDeInteiros.Add(item);
        }
    }
}
