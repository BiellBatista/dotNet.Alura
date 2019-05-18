using _03_04_XX_CasaDoCodigo.Models;
using _03_04_XX_CasaDoCodigo.Models.ViewModels;
using _03_04_XX_CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _03_04_XX_CasaDoCodigo.Controllers
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
            var pedido = pedidoRepository.GetPedido();

            if (pedido is null)
                return RedirectToAction("Carrossel");

            return View(pedido.Cadastro);
        }

        public IActionResult Carrinho(string codigoProduto)
        {
            if(!string.IsNullOrEmpty(codigoProduto))
            {
                pedidoRepository.AddItem(codigoProduto);
            }

            IList<ItemPedido> itens = pedidoRepository.GetPedido().Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return View(carrinhoViewModel);
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
        public UpdateQuantidadeResponse UpdateQuantidade([FromBody] ItemPedido itemPedido)
        {
            return pedidoRepository.UpdateQuantidade(itemPedido);
        }
    }
}
