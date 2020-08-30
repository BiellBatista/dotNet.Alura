using _05_04_XX_Implementando_IoC.Infraestrutura.Binding;
using _05_04_XX_Implementando_IoC.Infraestrutura.Filtros;
using _05_04_XX_Implementando_IoC.Infraestrutura.IoC;
using System;
using System.Net;
using System.Text;

namespace _05_04_XX_Implementando_IoC.Infraestrutura
{
    public class ManipuladorRequisicaoController
    {
        private readonly ActionBinder _actionBinder = new ActionBinder();
        private readonly ControllerResolve _controllerResolve;
        private readonly FilterResolver _filterResolver = new FilterResolver();

        public ManipuladorRequisicaoController(IContainer container)
        {
            _controllerResolve = new ControllerResolve(container);
        }

        public void Manipular(HttpListenerResponse resposta, string path)
        {
            var partes = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var controllerNome = partes[0];
            var controllerNomeCompleto = $"_05_04_XX_Implementando_IoC.Controller.{controllerNome}Controller";
            //var controllerWrapper = Activator.CreateInstance("_05_04_XX_Implementando_IoC", controllerNomeCompleto, new object[0]);
            //var controller = controllerWrapper.Unwrap();

            var controller = _controllerResolve.ObterController(controllerNomeCompleto);

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
