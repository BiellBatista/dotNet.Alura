using System;
using System.Net;

namespace _08_06_XX_Lendo_Atualizando_Banco_Dados.Depois
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