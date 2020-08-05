using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace _02_05_XX_Estilo_Codigo.R10.depois
{
    class MenuItem : _02_05_XX_Estilo_Codigo.MenuItem
    {
        public override async void Main()
        {
            //obs: O método acima seria o Main do programa: static void Main(string[] args)
            WriteLine(await _02_05_XX_Estilo_Codigo.R10.depois.MenuItem.GetGoogleAsync());
        }

        public static async Task<string> GetGoogleAsync()
        {
            return await new HttpClient().GetStringAsync("http://www.google.com");
        }
    }
}
