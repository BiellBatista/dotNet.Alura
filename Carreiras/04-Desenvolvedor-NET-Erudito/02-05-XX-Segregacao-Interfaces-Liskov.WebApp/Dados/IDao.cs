using System.Collections.Generic;

namespace _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Dados
{
    public interface IDao<T>
    {
        IEnumerable<T> BuscarTodos();
        T BuscarPorId(int id);
        void Incluir(T obj);
        void Alterar(T obj);
        void Excluir(T obj);
    }
}
