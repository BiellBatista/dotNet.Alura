using _03_03_XX_CasaDoCodigo.Models;
using System.Linq;

namespace _03_03_XX_CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {
        void UpdateQuantidade(ItemPedido itemPedido);
    }

    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public void UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = dbSet.Where(ip => ip.Id == itemPedido.Id).SingleOrDefault();

            if (itemPedido is null)
                return;

            itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);
            contexto.SaveChanges();
        }
    }
}
