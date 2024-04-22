using Dapper;
using DataAbstractions.Dapper;
using System.Data;

namespace DEMO.Infrastructure.Services;

public class SqlDataAccessor(IDataAccessor dataAccessor) : ISqlDataAccessor
{
    public async Task<T?> GetAsync<T>(string query, DynamicParameters parameters, CancellationToken ct) where T : class
    {
        var result =
            await dataAccessor.QueryAsync<T?>(new CommandDefinition(query, parameters, cancellationToken: ct));
        return result.FirstOrDefault();
    }

    public async Task<T> QuerySingle<T>(string query, DynamicParameters parameters, CancellationToken ct)
    {
        return await dataAccessor.QuerySingleAsync<T>(new CommandDefinition(query, parameters, cancellationToken: ct));
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, CancellationToken ct)
    {
        return await dataAccessor.QueryAsync<T>(new CommandDefinition(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure, cancellationToken: ct));
    }

    public async Task<int> InsertCommand(string command, DynamicParameters parameters, CancellationToken ct)
    {
        return await dataAccessor.QuerySingleAsync<int>(new CommandDefinition(command, parameters,
            cancellationToken: ct));
    }

    public async Task<int> UpdateCommand(string command, DynamicParameters parameters, CancellationToken ct)
    {
        return await dataAccessor.ExecuteAsync(new CommandDefinition(command, parameters, cancellationToken: ct));
    }

    public async Task SaveData<T>(string storedProcedure, T parameters, CancellationToken ct)
    {
        try
        {
            await dataAccessor.ExecuteAsync(new CommandDefinition(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, cancellationToken: ct));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task SaveDataReturn<T>(string storedProcedure, T parameters, CancellationToken ct)
    {
        try
        {
            await dataAccessor.ExecuteAsync(new CommandDefinition(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, cancellationToken: ct));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}