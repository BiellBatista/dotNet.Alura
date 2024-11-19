using System.Linq.Expressions;

namespace _04_XX_Seguranca.Dados.Repository.Base;

public interface IRepository<T>
{
    Task<IQueryable<T>> BuscarTodos();

    Task<T> BuscarPorId(Expression<Func<T, bool>> predicate);

    Task Adicionar(T entity);

    Task Atualizar(T entity);

    Task Deletar(T entity);
}