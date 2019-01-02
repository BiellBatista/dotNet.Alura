using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_XX_XX_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtratorValorArgumentosURL extrator = new ExtratorValorArgumentosURL("");

            string url = "pagina?argumentos";
            int indiceInterrogacao = url.IndexOf('?');

            Console.WriteLine(indiceInterrogacao);
            Console.WriteLine(url.Substring(0));

            Console.ReadLine();
        }
    }
}
