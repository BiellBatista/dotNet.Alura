using _04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente.Intraestrutura;
using _04_05_XX_Service;
using _04_05_XX_Service.Cambio;

namespace _04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente.Controller
{
    public class CambioController : ControllerBase
    {
        private ICambioService _cambioService;

        public CambioController()
        {
            _cambioService = new CambioTesteService();
        }

        public string MXN()
        {
            var valorFinal = _cambioService.Calcular("MXN", "BRL", 1);
            var textoPagina = View();
            var textoResultado = textoPagina.Replace("VALOR_EM_REAIS", valorFinal.ToString());

            return textoResultado;
        }

        public string USD()
        {
            var valorFinal = _cambioService.Calcular("USD", "BRL", 1);
            var textoPagina = View();
            var textoResultado = textoPagina.Replace("VALOR_EM_REAIS", valorFinal.ToString());

            return textoResultado;
        }

        public string Calculo(string moedaOrigem, string moedaDestino, decimal valor)
        {
            var valorFinal = _cambioService.Calcular(moedaOrigem, moedaDestino, valor);
            var textoPagina = View();
            var textoResultado = textoPagina
                .Replace("VALOR_MOEDA", valor.ToString())
                .Replace("MOEDA_ORIGEM", valorFinal.ToString())
                .Replace("VALOR_MOEDA_DESTINO", moedaOrigem)
                .Replace("MOEDA_DESTINO", moedaDestino);

            return textoResultado;
        }

        public string Calculo(string moedaDestino, decimal valor) => Calculo("BRL", moedaDestino, valor);

        public string Calculo(string moedaDestino) => Calculo("BRL", moedaDestino, 1);
    }
}
