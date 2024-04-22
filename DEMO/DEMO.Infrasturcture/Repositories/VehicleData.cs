using DEMO.Application.Features.Vehicles.Abstractions;
using DEMO.Application.Features.Vehicles.Requests;
using DEMO.Application.Features.Vehicles.Responses;
using DEMO.Client.Data;
using DEMO.Domain.Entities;
using DEMO.Domain.Shared;
using DEMO.Infrastructure.Services;
using Microsoft.Extensions.Logging;

namespace DEMO.Infrasturcture.Repositories;

public class VehicleData(ILogger<VehicleData> logger, ISqlDataAccessor sqlDataAccessor, ApplicationDbContext context)
    : IVehicleData
{
    public async Task<IEnumerable<VehicleResponse>> GetRolesAsync(GetVehicleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation($"Attempting to retrieve all vehicles from database");

            var results = await sqlDataAccessor.LoadData<VehicleResponse, dynamic>("YOUR_PROCEDURE_NAME", new
            {
                request.Id
            }, cancellationToken);

            return results;
        }
        catch (Exception e)
        {
            logger.LogCritical(e, $"Failed to retrieve vehicles from database");
            throw;
        }
    }

    public async Task<ApiResponse> CreateVehicleAsync(CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation($"Attempting to create new vehicle");

            await context.Vehicles.AddAsync(new Vehicle
            {
                Make = request.Make,
                Model = request.Model,
                Mileage = request.Mileage,
                Year = request.Year,
                Owners = request.Owners,
                DateCreated = DateTime.Now,
                Key = Guid.NewGuid()
            }, cancellationToken);

            var changes = await context.SaveChangesAsync(cancellationToken);

            if (changes <= 0)
                throw new Exception($"Failed to save changes while creating entity: {request}");

            return new ApiResponse("");
        }
        catch (Exception e)
        {
            logger.LogCritical(e, $"Failed to create new vehicle");
            throw;
        }
    }

    public async Task<ApiResponse> UpdateVehicleAsync(UpdateVehicleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation($"Attempting to update vehicle");

            var entity = context.Vehicles
                .FirstOrDefault(x => x.Id.Equals(request.Id));

            if (entity is not null)
            {
                entity.Make = request.Make;
                entity.Model = request.Model;
                entity.Mileage = request.Mileage;
                entity.Year = request.Year;
                entity.Owners = request.Owners;
                entity.DateModified = DateTime.Now;
            }

            var changes = await context.SaveChangesAsync(cancellationToken);

            if (changes <= 0)
                throw new Exception($"Failed to save changes for update to vehicle with id: {request.Id}");

            return new ApiResponse("");
        }
        catch (Exception e)
        {
            logger.LogCritical(e, $"Failed to update vehicle");
            throw;
        }
    }

    public async Task<ApiResponse> DeleteVehicleAsync(int Id, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation($"Attempting to delete vehicle");

            var entity = context.Vehicles
                .FirstOrDefault(x => x.Id.Equals(Id));

            var changes = await context.SaveChangesAsync(cancellationToken);

            if (changes <= 0)
                throw new Exception($"Failed to save changes for update to vehicle with id: {Id}");

            return new ApiResponse("");
        }
        catch (Exception e)
        {
            logger.LogCritical(e, $"Failed to delete vehicle");
            throw;
        }
    }
}