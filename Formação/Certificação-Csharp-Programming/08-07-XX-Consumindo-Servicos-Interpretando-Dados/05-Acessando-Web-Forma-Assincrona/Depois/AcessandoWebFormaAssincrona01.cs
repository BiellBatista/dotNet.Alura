using System;
using System.IO;
using System.Net;

namespace _08_07_XX_Consumindo_Servicos_Interpretando_Dados.Depois
{
    public class AcessandoWebFormaAssincrona01 : IAulaItem //HttpWebRequest
    {
        public void Executar()
        {
            //TAREFAS:
            //1) conectar-se site da caelum (http://www.caelum.com.br)
            //2) obter o conteúdo da página do site
            //3) exibir o conteúdo da página

            WebRequest requisicao = WebRequest.Create("http://www.caelum.com.br");
            WebResponse resposta = requisicao.GetResponse();

            using (var leitorResposta = new StreamReader(resposta.GetResponseStream()))
            {
                var textoDoSite = leitorResposta.ReadToEnd();

                Console.WriteLine(textoDoSite);
                Console.ReadKey();
            }
        }
    }
}