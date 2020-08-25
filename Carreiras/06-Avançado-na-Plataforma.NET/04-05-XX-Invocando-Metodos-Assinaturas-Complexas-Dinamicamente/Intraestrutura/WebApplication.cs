using System;
using System.Net;

namespace _04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente.Intraestrutura
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
            while (true)
            {
                ManipularRequisicao();
            }
        }

        private void ManipularRequisicao()
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

            var path = requisicao.Url.PathAndQuery;

            if (Utilidades.EhArquivo(path))
            {
                var manipulador = new ManipuladorRequisicaoArquivo();
                manipulador.Manipular(response, path);
            }
            else
            {
                var manipulador = new ManipuladorRequisicaoController();
                manipulador.Manipular(response, path);
            }

            httpListener.Stop();
        }
    }
}
