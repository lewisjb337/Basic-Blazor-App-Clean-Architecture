using DEMO.Application.Features.Vehicles.Abstractions;
using DEMO.Application.Features.Vehicles.Commands;
using DEMO.Domain.Shared;
using MediatR;

namespace DEMO.Application.Features.Vehicles.Handlers;

public class CreateVehicleHandler(IVehicleData vehicleData) : IRequestHandler<CreateVehicleCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(CreateVehicleCommand command, CancellationToken cancellationToken)
    {
        var results = await vehicleData.CreateVehicleAsync(command.Request, cancellationToken);

        return results;
    }
}