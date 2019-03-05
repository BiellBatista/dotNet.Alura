using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _02_Desenvolvedor_ASP_NET_MVC5.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required, StringLength(20), Range(0.0, 10000.0)]
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public CategoriaDoProduto Categoria { get; set; }
        public int? CategoriaId { get; set; }
        public string Descricao { get; set; }
        public int  Quantidade { get; set; }
    }
}