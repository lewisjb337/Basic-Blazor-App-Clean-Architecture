using DEMO.Application.Features.Vehicles.Commands;
using DEMO.Application.Features.Vehicles.Queries;
using DEMO.Application.Features.Vehicles.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DEMO.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VehiclesController(ISender sender) : BaseController
{
    /// <summary>
    /// Get all vehicles from the database.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetVehiclesAsync([FromQuery] GetVehicleRequest request, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetVehiclesQuery(request), cancellationToken);

        return Created("", response);
    }

    /// <summary>
    /// Create new vehicle entry.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateVehicleAsync([FromBody] CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new CreateVehicleCommand(request), cancellationToken);

        return Created("", response);
    }

    /// <summary>
    /// Update vehicle entry.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    public async Task<IActionResult> UpdateVehicleAsync([FromBody] UpdateVehicleRequest request, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new UpdateVehicleCommand(request), cancellationToken);

        return Created("", response);
    }

    /// <summary>
    /// Delete vehicle entry.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteVehicleAsync(int Id, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new DeleteVehicleCommand(Id), cancellationToken);

        return Created("", response);
    }
}