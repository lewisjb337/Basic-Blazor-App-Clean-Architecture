using DEMO.Application.Features.Vehicles.Requests;
using DEMO.Domain.Shared;
using MediatR;

namespace DEMO.Application.Features.Vehicles.Commands;

public record CreateVehicleCommand(CreateVehicleRequest Request) : IRequest<ApiResponse> { }
public record UpdateVehicleCommand(UpdateVehicleRequest Request) : IRequest<ApiResponse> { }
public record DeleteVehicleCommand(int Id) : IRequest<ApiResponse> { }