using System;
using System.Net;
using System.Reflection;

namespace _04_02_XX_Usando_Assembly_Dinamicamente_Convencoes.Intraestrutura
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

            var path = requisicao.Url.AbsolutePath;

            //retornando o assembly que está em execução no momento da chamada. O assembly retornado é o que chamou o método
            var assembly = Assembly.GetExecutingAssembly();
            var nomeResource = Utilidades.ConverterPathParaNomeAssembly(path);
            var resourceStream = assembly.GetManifestResourceStream(nomeResource);
            var bytesResource = new byte[resourceStream.Length];

            resourceStream.Read(bytesResource, 0, (int)resourceStream.Length);
            response.ContentType = Utilidades.ObterTipoDeConteudo(path);
            response.StatusCode = 200;
            response.ContentLength64 = resourceStream.Length;

            response.OutputStream.Write(bytesResource, 0, bytesResource.Length);
            response.OutputStream.Close();

            httpListener.Stop();
        }
    }
}
