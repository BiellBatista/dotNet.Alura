using System;
using System.Net;
using System.Text;

namespace _04_01_XX_O_Pontape_Nossa_Aplicacao_Web.Intraestrutura
{
    public class WebApplication
    {
        private readonly string[] _prefixos;

        public WebApplication(string[] prefixos)
        {
            if (prefixos == null)
            {
                throw new ArgumentNullException(nameof(prefixos));
            }

            _prefixos = prefixos;
        }

        public void Iniciar()
        {
            var httpListener = new HttpListener();

            foreach (var prefixo in _prefixos)
            {
                httpListener.Prefixes.Add(prefixo);
            }

            httpListener.Start();

            var contexto = httpListener.GetContext();
            var requisicao = contexto.Request;
            var response = contexto.Response;

            var resposta = "Hello World";
            var respostaBytes = Encoding.UTF8.GetBytes(resposta);

            response.ContentType = "text/html; charset=utf-8";
            response.StatusCode = 200;
            response.ContentLength64 = respostaBytes.Length;

            response.OutputStream.Write(respostaBytes, 0, respostaBytes.Length);
            response.OutputStream.Close();

            httpListener.Stop();
        }
    }
}
