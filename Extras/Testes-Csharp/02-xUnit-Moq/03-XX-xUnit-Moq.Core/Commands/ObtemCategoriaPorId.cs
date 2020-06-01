using _03_XX_xUnit_Moq.Core.Models;
using MediatR;

namespace _03_XX_xUnit_Moq.Core.Commands
{
    public class ObtemCategoriaPorId: IRequest<Categoria>
    {
        public ObtemCategoriaPorId(int idCategoria)
        {
            IdCategoria = idCategoria;
        }

        public int IdCategoria { get; }
    }
}
