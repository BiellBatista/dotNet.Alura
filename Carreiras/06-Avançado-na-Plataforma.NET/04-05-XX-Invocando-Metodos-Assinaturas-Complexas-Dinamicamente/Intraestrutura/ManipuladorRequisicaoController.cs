﻿using _04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente.Intraestrutura.Binding;
using System;
using System.Net;
using System.Text;

namespace _04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente.Intraestrutura
{
    public class ManipuladorRequisicaoController
    {
        private readonly ActionBinder _actionBinder = new ActionBinder();

        public void Manipular(HttpListenerResponse response, string path)
        {
            var partes = path.Split(new char[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
            var controllerName = partes[0];
            var actionName = partes[1];
            var controllerNomeCompleto = $"_04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente.Controller.{controllerName}Controller";
            //criando um objeto dinamicamente
            var controllerWrapper = Activator.CreateInstance("_04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente.Controller", controllerNomeCompleto, new object[0]);
            var controller = controllerWrapper.Unwrap();
            //pegando as informacoes de um metodo do objeto que foi criado dinamicamente
            //var methodInfo = controller.GetType().GetMethod(actionName);
            var methodInfo = _actionBinder.ObterActionBindInfo(controller, path);
            //chamando o método
            var resultAction = (string)methodInfo.Invoke(controller);

            var bufferArquivo = Encoding.UTF8.GetBytes(resultAction);

            response.StatusCode = 200;
            response.ContentType = "text/html; charset=utf-8";
            response.ContentLength64 = bufferArquivo.Length;
            response.OutputStream.Write(bufferArquivo, 0, bufferArquivo.Length);

            response.OutputStream.Close();
        }
    }
}
