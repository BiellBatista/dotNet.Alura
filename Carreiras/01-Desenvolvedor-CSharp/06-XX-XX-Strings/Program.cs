using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06_XX_XX_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            string padraoComQuantificadores = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]"; //é a mesma coisa de cima
            string padraoComQuantificadoresEMuntiplicadores = "[0-9]{4}[-][0-9]{4}"; //é a mesma coisa de cima (o {X} serve para mostrar que um padrão dentro de uma [] repete X vezes
            string padraoComQuantificadoresEMuntiplicadoresEIntervalo = "[0-9]{4,5}-{0,1}[0-9]{4}"; //é a mesma coisa de cima (o {X, Y} serve para mostrar que um padrão dentro de uma [] repete X vezes até Y vezes. No caso de um caracter, não preciso colocar o [], como no caso do -
            string padraoComQuantificadoresEMuntiplicadoresEIntervaloComInterrogação = "[0-9]{4,5}-?[0-9]{4}"; //é a mesma coisa de cima (o {X, Y} serve para mostrar que um padrão dentro de uma [] repete X vezes até Y vezes. No caso de um caracter, não preciso colocar o [], como no caso do -. O ? serve para mostrar que o caracter repete 0 ou 1 vez (tipo o {0, 1})
            string textoDeTeste = "Meu nome é Guilherme, me ligue em 4784-4546";

            Match resultado = Regex.Match(textoDeTeste, padrao); //retorna a cadeia de caracteres dentro do padrão (no caso, 4784-4546)

            Regex.IsMatch(textoDeTeste, padrao); //verifica se o input possui o padrão (true)
            Console.ReadLine();

            //Expressão Regulares acima
            //string urlTeste = "https://www.bytebank.com/cambio";
            //int indiceByteBank = urlTeste.IndexOf("https://www.bytebank.com");

            //Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com")); //verifica se uma string começa com uma string
            //Console.WriteLine(urlTeste.EndsWith("cambio")); //verifica se uma string termina com uma string
            //Console.WriteLine(urlTeste.Contains("cambio")); //verifica se uma string contem outra string
            //Console.WriteLine(indiceByteBank >= 0);


            //string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar";
            //ExtratorValorArgumentosURL extrator = new ExtratorValorArgumentosURL(urlParametros);
            //string valor = extrator.GetValor("moedaDestino");
            //string valorDaMoedaOrigem = extrator.GetValor("moedaOrigem");

            //Console.WriteLine("Valor de moedaDestino: " + valor); //escreve Valor de moedaDestino: dolar
            //Console.WriteLine("Valor de moedaOrigem: " + valorDaMoedaOrigem); //escreve Valor de moedaOrigem: real

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
