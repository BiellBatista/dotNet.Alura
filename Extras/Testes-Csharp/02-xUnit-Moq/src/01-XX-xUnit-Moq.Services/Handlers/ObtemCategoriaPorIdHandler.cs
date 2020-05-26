using _01_XX_xUnit_Moq.Core.Commands;
using _01_XX_xUnit_Moq.Core.Models;
using _01_XX_xUnit_Moq.Infrastructure;

namespace _01_XX_xUnit_Moq.Services.Handlers
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
