using _05_02_XX_Usando_Atributos_Filtros.Infraestrutura.Binding;
using System;
using System.Net;
using System.Text;

namespace _05_02_XX_Usando_Atributos_Filtros.Infraestrutura
{
    public class ManipuladorRequisicaoController
    {
        private readonly ActionBinder _actionBinder = new ActionBinder();

        public void Manipular(HttpListenerResponse resposta, string path)
        {
            var partes = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var controllerNome = partes[0];
            var actionNome = partes[1];

            var controllerNomeCompleto = $"_05_02_XX_Usando_Atributos_Filtros.Controller.{controllerNome}Controller";

            var controllerWrapper = Activator.CreateInstance("_05_02_XX_Usando_Atributos_Filtros", controllerNomeCompleto, new object[0]);
            var controller = controllerWrapper.Unwrap();

            //var methodInfo = controller.GetType().GetMethod(actionNome);
            var methodInfo = _actionBinder.ObterActionBindInfo(controller, path);

            var resultadoAction = (string)methodInfo.Invoke(controller);

            var buffer = Encoding.UTF8.GetBytes(resultadoAction);

            resposta.StatusCode = 200;
            resposta.ContentType = "text/html; charset=utf-8";
            resposta.ContentLength64 = buffer.Length;

            resposta.OutputStream.Write(buffer, 0, buffer.Length);
            resposta.OutputStream.Close();
        }
    }
}
