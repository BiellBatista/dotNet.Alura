using System.Collections.Generic;
using _02_04_XX_Inversao_Dependencias.WebApp.Models;

namespace _02_04_XX_Inversao_Dependencias.WebApp.Dados
{
    public interface ICategoriaDao
    {
        IEnumerable<Categoria> ConsultaCategorias();
        Categoria ConsultaCategoriaPorId(int id);
    }
}
