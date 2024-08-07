﻿using _05_01_XX_Service;
using _05_01_XX_Service.Cambio;
using _05_01_XX_Usando_Modelos_Nossa_View.Infraestrutura;
using _05_01_XX_Usando_Modelos_Nossa_View.Model;

namespace _05_01_XX_Usando_Modelos_Nossa_View.Controller
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
            var modelo = new CalculoCambioModel
            {
                MoedaDestino = moedaDestino,
                ValorDestino = valorFinal,
                MoedaOrigem = moedaOrigem,
                ValorOrigem = valor
            };

            return View(modelo);
        }

        public string Calculo(string moedaDestino, decimal valor) =>
            Calculo("BRL", moedaDestino, valor);

        public string Calculo(string moedaDestino) =>
            Calculo("BRL", moedaDestino, 1);
    }
}
