using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace _02_05_XX_Estilo_Codigo.R10.antes
{
    class MenuItem : _02_05_XX_Estilo_Codigo.MenuItem
    {
        public override void Main()
        {
            //obs: O método acima seria o Main do programa: static void Main(string[] args)
            WriteLine(_02_05_XX_Estilo_Codigo.R10.antes.MenuItem.GetGoogleAsync().GetAwaiter().GetResult());
        }

        public static async Task<string> GetGoogleAsync()
        {
            return await new HttpClient().GetStringAsync("http://www.google.com");
        }
    }
}
