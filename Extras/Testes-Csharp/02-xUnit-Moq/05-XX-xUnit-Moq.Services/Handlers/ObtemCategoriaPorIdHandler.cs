using _05_XX_xUnit_Moq.Core.Commands;
using _05_XX_xUnit_Moq.Core.Models;
using _05_XX_xUnit_Moq.Infrastructure;

namespace _05_XX_xUnit_Moq.Services.Handlers
{
    public class ObtemCategoriaPorIdHandler
    {
        IRepositorioTarefas _repo;

        public ObtemCategoriaPorIdHandler(IRepositorioTarefas repositorio)
        {
            _repo = repositorio;
        }

        public Categoria Execute(ObtemCategoriaPorId comando)
        {
            return _repo.ObtemCategoriaPorId(comando.IdCategoria);
        }
    }
}
