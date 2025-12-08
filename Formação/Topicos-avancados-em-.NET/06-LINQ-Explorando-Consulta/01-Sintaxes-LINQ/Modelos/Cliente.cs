using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Sintaxes_LINQ.Modelos;
public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public List<Pedido> Pedidos { get; set; }
}
