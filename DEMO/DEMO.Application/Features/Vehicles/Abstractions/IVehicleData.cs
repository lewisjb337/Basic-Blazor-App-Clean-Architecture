using DEMO.Application.Features.Vehicles.Requests;
using DEMO.Application.Features.Vehicles.Responses;
using DEMO.Domain.Shared;

namespace DEMO.Application.Features.Vehicles.Abstractions;

public interface IVehicleData
{
    Task<IEnumerable<VehicleResponse>> GetRolesAsync(GetVehicleRequest request, CancellationToken cancellationToken = default);
    Task<ApiResponse> CreateVehicleAsync(CreateVehicleRequest request, CancellationToken cancellationToken = default);
    Task<ApiResponse> UpdateVehicleAsync(UpdateVehicleRequest request, CancellationToken cancellationToken = default);
    Task<ApiResponse> DeleteVehicleAsync(int Id, CancellationToken cancellationToken = default);
}