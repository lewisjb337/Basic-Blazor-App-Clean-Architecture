using DEMO.Application.Features.Vehicles.Requests;
using DEMO.Application.Features.Vehicles.Responses;
using MediatR;

namespace DEMO.Application.Features.Vehicles.Queries;

public record GetVehiclesQuery(GetVehicleRequest Request) : IRequest<IEnumerable<VehicleResponse>> { }