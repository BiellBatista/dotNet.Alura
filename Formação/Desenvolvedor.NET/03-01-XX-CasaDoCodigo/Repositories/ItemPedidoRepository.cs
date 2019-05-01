using _03_01_XX_CasaDoCodigo.Models;

namespace _03_01_XX_CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {

    }

    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
