using DEMO.Application.Features.Vehicles.Abstractions;
using DEMO.Application.Features.Vehicles.Commands;
using DEMO.Domain.Shared;
using MediatR;

namespace DEMO.Application.Features.Vehicles.Handlers;

public class DeleteVehicleHandler(IVehicleData vehicleData) : IRequestHandler<DeleteVehicleCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(DeleteVehicleCommand command, CancellationToken cancellationToken)
    {
        var results = await vehicleData.DeleteVehicleAsync(command.Id, cancellationToken);

        return results;
    }
}