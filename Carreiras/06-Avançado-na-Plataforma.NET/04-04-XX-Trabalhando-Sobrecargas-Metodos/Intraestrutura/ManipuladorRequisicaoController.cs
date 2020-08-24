using _04_04_XX_Trabalhando_Sobrecargas_Metodos.Intraestrutura.Binding;
using System;
using System.Net;
using System.Text;

namespace _04_04_XX_Trabalhando_Sobrecargas_Metodos.Intraestrutura
{
    public class ManipuladorRequisicaoController
    {
        private readonly ActionBinder _actionBinder = new ActionBinder();

        public void Manipular(HttpListenerResponse response, string path)
        {
            var partes = path.Split(new char[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
            var controllerName = partes[0];
            var actionName = partes[1];
            var controllerNomeCompleto = $"_04_04_XX_Trabalhando_Sobrecargas_Metodos.Controller.{controllerName}Controller";
            //criando um objeto dinamicamente
            var controllerWrapper = Activator.CreateInstance("_04_04_XX_Trabalhando_Sobrecargas_Metodos.Controller", controllerNomeCompleto, new object[0]);
            var controller = controllerWrapper.Unwrap();
            //pegando as informacoes de um metodo do objeto que foi criado dinamicamente
            //var methodInfo = controller.GetType().GetMethod(actionName);
            var methodInfo = _actionBinder.ObterMethodInfo(controller, path);
            //chamando o método
            var resultAction = (string)methodInfo.Invoke(controller, new object[0]);

            var bufferArquivo = Encoding.UTF8.GetBytes(resultAction);

            response.StatusCode = 200;
            response.ContentType = "text/html; charset=utf-8";
            response.ContentLength64 = bufferArquivo.Length;
            response.OutputStream.Write(bufferArquivo, 0, bufferArquivo.Length);

            response.OutputStream.Close();
        }
    }
}
