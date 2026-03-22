using System.Linq.Expressions;

namespace _01_06_Aprovacao_propostas.Contracts;

public interface IRepository<T>
{
    Task<T> AddAsync(
        T obj
        , CancellationToken cancellationToken = default);

    Task<T> UpdateAsync(
        T obj
        , CancellationToken cancellationToken = default);

    Task RemoveAsync(
        T obj
        , CancellationToken cancellationToken = default);

    Task<T?> GetFirstAsync<TProperty>(
        Expression<Func<T, bool>> filtro
        , Expression<Func<T, TProperty>> orderBy
        , CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> GetWhereAsync(
        Expression<Func<T, bool>>? filtro = default
        , CancellationToken cancellationToken = default);
}