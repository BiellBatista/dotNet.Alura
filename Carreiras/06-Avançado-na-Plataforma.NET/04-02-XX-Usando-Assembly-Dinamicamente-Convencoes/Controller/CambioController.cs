using _04_02_XX_Service;
using _04_02_XX_Service.Cambio;
using System.IO;
using System.Reflection;

namespace _04_02_XX_Usando_Assembly_Dinamicamente_Convencoes.Controller
{
    public class CambioController
    {
        private ICambioService _cambioService;

        public CambioController()
        {
            _cambioService = new CambioTesteService();
        }

        public string MXN()
        {
            var valorFinal = _cambioService.Calcular("MXN", "BRL", 1);
            var nomeCompletoResource = "04-02-XX-Usando-Assembly-Dinamicamente-Convencoes.View.Cambio.MXN.html";
            var assembly = Assembly.GetExecutingAssembly();
            var streamRecurso = assembly.GetManifestResourceStream(nomeCompletoResource);
            var streamLeitura = new StreamReader(streamRecurso);
            var textoPagina = streamLeitura.ReadToEnd();
            var textoResultado = textoPagina.Replace("VALOR_EM_REAIS", valorFinal.ToString());

            return textoResultado;
        }

        public string USD()
        {
            return null;
        }
    }
}
