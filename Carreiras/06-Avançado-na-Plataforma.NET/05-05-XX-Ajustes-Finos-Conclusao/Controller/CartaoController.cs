using _05_05_XX_Ajustes_Finos_Conclusao.Infraestrutura;
using _05_05_XX_Service;

namespace _05_05_XX_Ajustes_Finos_Conclusao.Controller
{
    public class CartaoController : ControllerBase
    {
        private ICartaoService _cartaoService;

        public CartaoController(ICartaoService cartaoService)
        {
            _cartaoService = cartaoService;
        }

        public string Debito() => View(new
        {
            CartaoNome = _cartaoService.ObterCartaoDeDebitoDeDestaque()
        });

        public string Credito() => View(new
        {
            CartaoNome = _cartaoService.ObterCartaoDeCreditoDeDestaque()
        });
    }
}
