using DEMO.Application.Features.Vehicles.Abstractions;
using DEMO.Application.Features.Vehicles.Queries;
using DEMO.Application.Features.Vehicles.Responses;
using MediatR;

namespace DEMO.Application.Features.Vehicles.Handlers;

public class GetVehiclesHandler(IVehicleData vehicleData) : IRequestHandler<GetVehiclesQuery, IEnumerable<VehicleResponse>>
{
    public async Task<IEnumerable<VehicleResponse>> Handle(GetVehiclesQuery query, CancellationToken cancellationToken)
    {
        var results = await vehicleData.GetRolesAsync(query.Request, cancellationToken);

        return results;
    }
}