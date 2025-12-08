using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Sintaxes_LINQ.Modelos;
public class Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public string Descricao { get; set; }
}
