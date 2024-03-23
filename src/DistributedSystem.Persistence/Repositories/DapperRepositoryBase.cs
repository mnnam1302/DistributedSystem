using Dapper;
using DistributedSystem.Domain.Abstractions.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DistributedSystem.Persistence.Repositories;

public class DapperRepositoryBase : IDapperRepositoryBase, IDisposable
{
    private readonly IDbConnection _connection;

    public DapperRepositoryBase(IConfiguration configuration)
    {
        _connection = new SqlConnection(configuration.GetConnectionString("ConnectionStrings"));
    }

    public void Dispose()
    {
        _connection?.Dispose();
    }

    public async Task<TResult> QueryFirstOrDefaultAsync<TResult>(string sql, object? param = null, CancellationToken cancellationToken = default)
    {
        return await _connection.QueryFirstOrDefaultAsync<TResult>(sql, param);
    }

    public async Task<TResult> QuerySingleAsync<TResult>(string sql, object? param = null, CancellationToken cancellationToken = default)
    {
        return await _connection.QuerySingleAsync<TResult>(sql, param);
    }

    // IO Bound
    public async Task<IReadOnlyList<TResult>> QueryAsync<TResult>(string sql, object? param = null, CancellationToken cancellationToken = default)
    {
        return (await _connection.QueryAsync<TResult>(sql, param)).ToList();
    }

    /*
     * How to Map
     * One-to-one relationships
     * One-to-many relationships
     * Many-to-many relationships
     */
    public async Task<IEnumerable<TResult>> QueryMapAsync<TEntity1, TEntity2, TResult>(string sql, Func<TEntity1, TEntity2, TResult> map, object? param, string splitOn = "Id", CancellationToken cancellationToken = default)
    {
        return await _connection.QueryAsync(sql, map, param, null, true, splitOn);
    }

    public async Task<IEnumerable<TResult>> QueryMapAsync<TEntity1, TEntity2, TEntity3, TResult>(string sql, Func<TEntity1, TEntity2, TEntity3, TResult> map, object? param, string splitOn = "Id", CancellationToken cancellationToken = default)
    {
        return await _connection.QueryAsync(sql, map, param, null, true, splitOn);
    }
}
