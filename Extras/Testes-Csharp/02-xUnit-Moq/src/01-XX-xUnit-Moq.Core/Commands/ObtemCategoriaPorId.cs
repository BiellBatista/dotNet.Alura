using _01_XX_xUnit_Moq.Core.Models;
using MediatR;

namespace _01_XX_xUnit_Moq.Core.Commands
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
