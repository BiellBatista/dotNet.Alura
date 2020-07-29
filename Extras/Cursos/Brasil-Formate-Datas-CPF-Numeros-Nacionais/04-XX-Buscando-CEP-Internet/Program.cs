using System.Diagnostics;
using System.Net.Http;

namespace _04_XX_Buscando_CEP_Internet
{
    class Program
    {
        static void Main(string[] args)
        {
            string cep = "01001000";
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            string result = new HttpClient().GetStringAsync(url).Result;

            Debug.WriteLine(result);
        }
    }
}
