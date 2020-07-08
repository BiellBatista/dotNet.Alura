using System.Collections.Generic;

namespace _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Dados
{
    public interface IQuery<T>
    {
        IEnumerable<T> BuscarTodos();
        T BuscarPorId(int id);
    }
}
