using _05_03_XX_Conhecendo_IoC.Infraestrutura.Binding;
using _05_03_XX_Conhecendo_IoC.Infraestrutura.Filtros;
using System;
using System.Net;
using System.Text;

namespace _05_03_XX_Conhecendo_IoC.Infraestrutura
{
    public class ManipuladorRequisicaoController
    {
        private readonly ActionBinder _actionBinder = new ActionBinder();
        private readonly FilterResolver _filterResolver = new FilterResolver();

        public void Manipular(HttpListenerResponse resposta, string path)
        {
            var partes = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var controllerNome = partes[0];
            var controllerNomeCompleto = $"_05_03_XX_Conhecendo_IoC.Controller.{controllerNome}Controller";
            var controllerWrapper = Activator.CreateInstance("_05_03_XX_Conhecendo_IoC", controllerNomeCompleto, new object[0]);
            var controller = controllerWrapper.Unwrap();
            var actionBindInfo = _actionBinder.ObterActionBindInfo(controller, path);
            var filterResult = _filterResolver.VerificarFiltros(actionBindInfo);

            if (filterResult.PodeContinuar)
            {
                var resultadoAction = (string)actionBindInfo.Invoke(controller);
                var buffer = Encoding.UTF8.GetBytes(resultadoAction);

                resposta.StatusCode = 200;
                resposta.ContentType = "text/html; charset=utf-8";
                resposta.ContentLength64 = buffer.Length;
                resposta.OutputStream.Write(buffer, 0, buffer.Length);
                resposta.OutputStream.Close();
            }
            else
            {
                resposta.StatusCode = 307;
                resposta.RedirectLocation = "/Erro/Inesperado";
                resposta.OutputStream.Close();
            }
        }
    }
}
