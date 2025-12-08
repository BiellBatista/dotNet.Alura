using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Sintaxes_LINQ.Modelos;
public class Pagamento
{
    public Guid Id { get; set; }
    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; }
    public string FormaPagamento { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime Data { get; set; }
}