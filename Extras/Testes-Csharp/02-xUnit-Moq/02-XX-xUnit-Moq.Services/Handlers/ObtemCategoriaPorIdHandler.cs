using _02_XX_xUnit_Moq.Core.Commands;
using _02_XX_xUnit_Moq.Core.Models;
using _02_XX_xUnit_Moq.Infrastructure;

namespace _02_XX_xUnit_Moq.Services.Handlers
{
    public class ObtemCategoriaPorIdHandler
    {
        IRepositorioTarefas _repo;

        public ObtemCategoriaPorIdHandler()
        {
            _repo = new RepositorioTarefa();
        }
        public Categoria Execute(ObtemCategoriaPorId comando)
        {
            return _repo.ObtemCategoriaPorId(comando.IdCategoria);
        }
    }
}
