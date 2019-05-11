using _03_03_XX_CasaDoCodigo.Models;
using _03_03_XX_CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _03_03_XX_CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Carrinho(string codigoProduto)
        {
            if(!string.IsNullOrEmpty(codigoProduto))
            {
                pedidoRepository.AddItem(codigoProduto);
            }

            Pedido pedido = pedidoRepository.GetPedido();
            return View(pedido.Itens);
        }

        public IActionResult Carrossel()
        {
            return View(produtoRepository.GetProdutos());
        }

        public IActionResult Resumo()
        {
            Pedido pedido = pedidoRepository.GetPedido();

            return View(pedido);
        }

        [HttpPost]
        public void UpdateQuantidade([FromBody] ItemPedido itemPedido)
        {
            itemPedidoRepository.UpdateQuantidade(itemPedido);
        }
    }
}
