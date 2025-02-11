﻿using System.Net;
using System.Reflection;

namespace _04_04_XX_Trabalhando_Sobrecargas_Metodos.Intraestrutura
{
    public class ManipuladorRequisicaoArquivo
    {
        public void Manipular(HttpListenerResponse response, string path)
        {
            //retornando o assembly que está em execução no momento da chamada. O assembly retornado é o que chamou o método
            var assembly = Assembly.GetExecutingAssembly();
            var nomeResource = Utilidades.ConverterPathParaNomeAssembly(path);
            var resourceStream = assembly.GetManifestResourceStream(nomeResource);

            if (resourceStream == null)
            {
                response.StatusCode = 404;
                response.OutputStream.Close();
            }
            else
            {
                using (resourceStream)
                {
                    var bytesResource = new byte[resourceStream.Length];

                    resourceStream.Read(bytesResource, 0, (int)resourceStream.Length);
                    response.ContentType = Utilidades.ObterTipoDeConteudo(path);
                    response.StatusCode = 200;
                    response.ContentLength64 = resourceStream.Length;

                    response.OutputStream.Write(bytesResource, 0, bytesResource.Length);
                    response.OutputStream.Close();
                }
            }
        }
    }
}
