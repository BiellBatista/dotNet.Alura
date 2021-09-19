using System.Collections.Generic;
using System.Linq;

namespace _10_05_XX_Tipos_System_Reflection.Depois.Modelo
{
    public class CarrinhoCliente
    {
        public CarrinhoCliente()
        {
        }

        public CarrinhoCliente(string clienteId)
        {
            ClienteId = clienteId;
            Itens = new List<ItemCarrinho>();
        }

        public CarrinhoCliente(CarrinhoCliente carrinhoCliente)
        {
            ClienteId = carrinhoCliente.ClienteId;
            Itens = carrinhoCliente.Itens;
        }

        public string ClienteId { get; set; }
        public List<ItemCarrinho> Itens { get; set; }
        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);
    }
}