using Dapper;

namespace DEMO.Infrastructure.Services;

public interface ISqlDataAccessor
{
    Task<T?> GetAsync<T>(string query, DynamicParameters parameters, CancellationToken ct = default) where T : class;
    Task<T> QuerySingle<T>(string query, DynamicParameters parameters, CancellationToken ct = default);
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, CancellationToken ct = default);
    Task<int> InsertCommand(string command, DynamicParameters parameters, CancellationToken ct = default);
    Task<int> UpdateCommand(string command, DynamicParameters parameters, CancellationToken ct = default);
    Task SaveData<T>(string storedProcedure, T parameters, CancellationToken ct = default);
    Task SaveDataReturn<T>(string storedProcedure, T parameters, CancellationToken ct = default);
}