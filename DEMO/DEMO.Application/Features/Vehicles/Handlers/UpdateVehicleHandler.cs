using DEMO.Application.Features.Vehicles.Abstractions;
using DEMO.Application.Features.Vehicles.Commands;
using DEMO.Domain.Shared;
using MediatR;

namespace DEMO.Application.Features.Vehicles.Handlers;

public class UpdateVehicleHandler(IVehicleData vehicleData) : IRequestHandler<UpdateVehicleCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(UpdateVehicleCommand command, CancellationToken cancellationToken)
    {
        var results = await vehicleData.UpdateVehicleAsync(command.Request, cancellationToken);

        return results;
    }
}