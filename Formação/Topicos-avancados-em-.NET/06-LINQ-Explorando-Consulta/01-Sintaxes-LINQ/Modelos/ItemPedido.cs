using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Sintaxes_LINQ.Modelos;
public class ItemPedido
{
    public Guid Id { get; set; }
    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; }
    public Guid ProdutoId { get; set; }
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
}
