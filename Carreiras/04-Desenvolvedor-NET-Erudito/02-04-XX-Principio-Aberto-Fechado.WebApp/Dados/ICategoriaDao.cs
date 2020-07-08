using System.Collections.Generic;
using _02_04_XX_Principio_Aberto_Fechado.WebApp.Models;

namespace _02_04_XX_Principio_Aberto_Fechado.WebApp.Dados
{
    public interface ICategoriaDao
    {
        IEnumerable<Categoria> ConsultaCategorias();
        Categoria ConsultaCategoriaPorId(int id);
    }
}
