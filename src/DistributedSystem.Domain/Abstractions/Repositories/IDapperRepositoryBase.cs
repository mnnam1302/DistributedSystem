namespace DistributedSystem.Domain.Abstractions.Repositories;

public interface IDapperRepositoryBase
{
    Task<TResult> QueryFirstOrDefaultAsync<TResult>(string sql, object? param = null, CancellationToken cancellationToken = default);

    Task<TResult> QuerySingleAsync<TResult>(string sql, object? param = null, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<TResult>> QueryAsync<TResult>(string sql, object? param = null, CancellationToken cancellationToken = default);

    Task<IEnumerable<TResult>> QueryMapAsync<TEntity1, TEntity2, TResult>(string sql,
        Func<TEntity1, TEntity2, TResult> map,
        object? param,
        string splitOn = "Id",
        CancellationToken cancellationToken = default);

    Task<IEnumerable<TResult>> QueryMapAsync<TEntity1, TEntity2, TEntity3, TResult>(string sql,
        Func<TEntity1, TEntity2, TEntity3, TResult> map,
        object? param,
        string splitOn = "Id",
        CancellationToken cancellationToken = default);
}
