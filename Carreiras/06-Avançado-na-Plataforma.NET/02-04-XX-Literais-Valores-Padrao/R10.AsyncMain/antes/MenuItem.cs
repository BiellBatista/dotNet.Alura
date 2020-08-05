using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace _02_04_XX_Literais_Valores_Padrao.R10.antes
{
    class MenuItem : _02_04_XX_Literais_Valores_Padrao.MenuItem
    {
        public override void Main()
        {
            //obs: O método acima seria o Main do programa: static void Main(string[] args)
            WriteLine(_02_04_XX_Literais_Valores_Padrao.R10.antes.MenuItem.GetGoogleAsync().GetAwaiter().GetResult());
        }

        public static async Task<string> GetGoogleAsync()
        {
            return await new HttpClient().GetStringAsync("http://www.google.com");
        }
    }
}
