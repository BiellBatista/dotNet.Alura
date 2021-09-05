using System;
using System.Net;
using System.Threading.Tasks;

namespace _08_05_XX_Acessando_Web_Forma_Assincrona.Depois
{
    public class AcessandoWebFormaAssincrona03 : IAulaItem //WebClient async
    {
        public void Executar()
        {
            //TAREFA:
            //Conectar-se site da caelum (http://www.caelum.com.br)
            //apenas para obter e exibir o conteúdo da página do site
            //de forma ASSÍNCRONA

            string textoDoSite = LerTextoDoSite().Result;

            Console.WriteLine(textoDoSite);
            Console.ReadKey();
        }

        private async Task<string> LerTextoDoSite()
        {
            WebClient webClient = new WebClient();
            var textoDoSite = await webClient.DownloadStringTaskAsync("http://www.caelum.com.br");

            return textoDoSite;
        }
    }
}