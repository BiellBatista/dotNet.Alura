using System;
using System.Net;

namespace _08_05_XX_Acessando_Web_Forma_Assincrona.Depois
{
    public class AcessandoWebFormaAssincrona02 : IAulaItem //WebClient
    {
        public void Executar()
        {
            //TAREFA:
            //Conectar-se site da caelum (http://www.caelum.com.br)
            //apenas para obter e exibir o conteúdo da página do site
            //mas de forma mais simples e rápida

            WebClient webClient = new WebClient();
            string textoDoSite = webClient.DownloadString("http://www.caelum.com.br");

            Console.WriteLine(textoDoSite);
            Console.ReadKey();
        }
    }
}