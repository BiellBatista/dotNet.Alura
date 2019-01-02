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
            string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar";
            ExtratorValorArgumentosURL extrator = new ExtratorValorArgumentosURL(urlParametros);
            string valor = extrator.GetValor("moedaDestino");
            string valorDaMoedaOrigem = extrator.GetValor("moedaOrigem");

            Console.WriteLine("Valor de moedaDestino: " + valor); //escreve Valor de moedaDestino: dolar
            Console.WriteLine("Valor de moedaOrigem: " + valorDaMoedaOrigem); //escreve Valor de moedaOrigem: real




            //string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar";
            //ExtratorValorArgumentosURL extrator = new ExtratorValorArgumentosURL(urlParametros);
            //string valor = extrator.GetValor("moedaDestino");

            //Console.WriteLine("Valor de moedaDestino: " + valor);

            //string testeRemocao = "primeiraParte&parteParaRemover";
            //int indiceEComercial = testeRemocao.IndexOf('&');

            //Console.WriteLine(testeRemocao.Remove(indiceEComercial));

            /*ExtratorValorArgumentosURL extrator = new ExtratorValorArgumentosURL("");

            string url = "pagina?argumentos";
            int indiceInterrogacao = url.IndexOf('?');

            Console.WriteLine(indiceInterrogacao);
            Console.WriteLine(url.Substring(0));
            */
            Console.ReadLine();
        }
    }
}
