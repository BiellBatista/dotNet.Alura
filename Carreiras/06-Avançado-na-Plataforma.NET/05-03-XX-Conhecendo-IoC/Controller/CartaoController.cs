using _05_03_XX_Conhecendo_IoC.Infraestrutura;
using _05_03_XX_Service;
using _05_03_XX_Service.Cartao;

namespace _05_03_XX_Conhecendo_IoC.Controller
{
    public class CartaoController : ControllerBase
    {
        private ICartaoService _cartaoService;

        public CartaoController()
        {
            _cartaoService = new CartaoServiceTeste();
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
