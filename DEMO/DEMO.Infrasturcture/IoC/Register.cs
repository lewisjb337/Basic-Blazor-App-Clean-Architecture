using DataAbstractions.Dapper;
using DEMO.Application.Features.Vehicles.Abstractions;
using DEMO.Infrastructure.Services;
using DEMO.Infrasturcture.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace DEMO.Infrasturcture.IoC;

public static class Register
{
    public static void AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<ISqlDataAccessor, SqlDataAccessor>();
        services.AddScoped<IVehicleData, VehicleData>();
        services.AddTransient<IDataAccessor, DataAccessor>(database => new DataAccessor(new SqlConnection(connectionString)));
    }
}