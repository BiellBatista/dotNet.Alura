using _05_03_XX_Conhecendo_IoC.Infraestrutura;
using _05_03_XX_Service;

namespace _05_03_XX_Conhecendo_IoC.Controller
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
